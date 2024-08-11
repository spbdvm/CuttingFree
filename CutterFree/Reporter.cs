using CuttingStock;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace CutterX
{
    public static class Reporter
    {

  
        /// <summary>
        /// Get text list frm cutting
        /// </summary>
        /// <param name="cutt">array of cuttings </param>
        /// <param name="sumformat"> sum format of cutting string  </param>
        /// <returns></returns>
        public static List<string> CreateReportTextStrings(CuttingPlan cutt , bool sumformat = true  )
        {
            //We use * 10 because   cutting library use Int but soft need 0.1 accuracy

            List<string> list = new List<string>();
            if (cutt ==null ) return list;

            string result   = string.Empty;
            // all reik generate string
            for (int i = 1; i <= cutt.UsedBars; i++)
            {
                string rs = "";
                for (int j = 0; j < cutt.CutSchemeMapping.Length; j++)
                {
        
                    // if cutting map is equal 
                    if ( cutt.CutSchemeMapping[j] == i)
                    { 
                         rs =rs +  (cutt.CutSchemeLengths[j] - cutt.Waste).div10().ToString() + " +";
            
                        }
                }
                string str = sumformat ? rs.delPlus().SumStringFormat() : rs.delPlus();

            
                rs =   str  + "  ( summ " + cutt.UsedBarLengths[i-1].div10().fmt(1) + " rem  " + (cutt.RawMaterial.div10() - cutt.UsedBarLengths[i - 1].div10()).fmt(1)   + " )";

                list.Add ( rs.delPlus().Trim());
            }

            return list;

        }


        /// <summary>
        /// Convert string with numbers to num-count format
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string SumStringFormat(this string input)
        {
            string[] numbers = Regex.Matches(input, @"[0-9]+(?:\,[0-9]+)?")
                               .Cast<Match>()
                               .Select(m => m.Value)
                               .ToArray();

            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string number in numbers)
            {
                if (counts.ContainsKey(number))
                {
                    counts[number]++;
                }
                else
                {
                    counts[number] = 1;
                }
            }

            string result = string.Join(", ", counts.Select(kv => $"{kv.Key} - {kv.Value} pc"));
            return result;

        }


        public static string delPlus(this string s)
        { 
          if( (s.EndsWith("+"))  && s.Length>2)
                s=  s.Substring(0, s.Length -1);

            return s;
        }

        public static string fmt  (this object s , int num =1)
        {
            string n = "";
            for (int i = 0; i < num; i++)
            {
                n = n + "0";
            }

           return  string.Format("{0:0." + n  + "}", s);
        }

        //divide 10 
        public static double div10(this int n)
        {
            return n * 0.1;
        }



       public static string[] Wrap(this string text, int max)
            {
                var charCount = 0;
                var lines = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return lines.GroupBy(w => (charCount += (((charCount % max) + w.Length + 1 >= max)
                                ? max - (charCount % max) : 0) + w.Length + 1) / max)
                            .Select(g => string.Join(" ", g.ToArray()))
                            .ToArray();
            }


        //multiply 10
        public static int[] m10arr (this List<double> lst)
        {
               return  lst.Select(i =>  Convert.ToInt32( i*10)).ToArray();
        }


        /// <summary>
        /// Create XLS report
        /// </summary>
        /// <param name="cuttList"></param>
            internal static void GenerateReport(List<resCut> cuttList)
        {
            #region Select Folder for Output
            AppSettings.loadSettingsIni();
            string folderName = AppSettings.lastFolderOut;
            var folderBrowserDialog = new FolderBrowserEx.FolderBrowserDialog();
            folderBrowserDialog.Title = "Select  a folder";
            folderBrowserDialog.InitialFolder = AppSettings.lastFolderOut;
            folderBrowserDialog.AllowMultiSelect = false;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderName = folderBrowserDialog.SelectedFolder;
            }

            if (Path.GetDirectoryName(folderName) != AppSettings.lastFolderOut)
            {
                AppSettings.lastFolderOut = Path.GetDirectoryName(folderName);
                AppSettings.WriteIni();
            }
            #endregion

            FileInfo newFile = new FileInfo(folderName + @"\" + "Cutting" + ".xlsx");
            if (newFile.Exists)
            {
                newFile.Delete();  // ensures we create a new workbook
                newFile = new FileInfo(folderName + @"\" + "Cutting" + ".xlsx");
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("CuttingMap");
                worksheet.Column(1).Width = 15;
                worksheet.Column(2).Width = 15;

                worksheet.Cells[1, 2].Value = "Map of Cutting";
                worksheet.Cells[3, 2].Value = "Calculation of   " + System.DateTime.Today.ToShortDateString();

                int i = 5;//exxel row counter
                foreach (resCut cut in cuttList)
                {
                    var cutt = cut.cutt;
                    var artSettings = cut.artSettl;

                    //header of artikl
                    worksheet.Cells[i, 2].Value = artSettings.Art;                    
                    worksheet.Cells[i, 3].Value = "Lenght " + artSettings.ProfileLength.ToString() + " mm.";
                    i++;
                    //Cutting 
                    worksheet.Cells[i, 1].Value = "Count";
                    worksheet.Cells[i, 2].Value = "Cutting map";                    
                    i++;

                    var lstString = CreateReportTextStrings(cutt, AppSettings.SumEqualSegment);
                    //Group similar

                    var groupedLst = lstString
                    .GroupBy(s => s)
                    .Select(g => new { Symbol = g.Key, Count = g.Count() });
                    foreach (var item in groupedLst)
                    {
                        worksheet.Cells[i, 1].Value = item.Count.fmt(0);
                        worksheet.Cells[i, 2].Value = item.Symbol;
                        i++;
                    }

                    worksheet.Cells[i, 1].Value = "Total :";
                    worksheet.Cells[i, 2].Value = cutt.UsedBars.ToString();
                    i++;
                    i++;

                }


                // set 11 font size
                ExcelRange cells = worksheet.Cells[1, 1, i + 1, 10];//get 10 cells in row 1 
                cells.Style.Font.Size = 11;

                package.Save();
            }



            }
    }
}
