using CuttingStock;
using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CutterX
{
    public partial class FormCutter : Form
    {
        List<resCut> cuttList = new List<resCut>();

        string lastFolder = "";
        FileIniDataParser parser;
        int protokol = 0;
        List<string> FileNames = new List<string>();
        private string myFile;

        DataTable dtLen = new DataTable();
        private BindingSource _sourceArt = new BindingSource();

        public FormCutter()
        {
          
            InitializeComponent();
            AppSettings.loadSettingsIni();
            SetLanguageRU();
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            try
            {

                cuttList.Clear();
                AppSettings.loadSettingsIni();

                var dilog = new OpenFileDialog();
                dilog.FileName = "Excel files";
                dilog.DefaultExt = ".xlsx";
                dilog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                dilog.InitialDirectory = AppSettings.lastFolder;

                ///show open file dialog box 
                if (dilog.ShowDialog() == DialogResult.OK)
                {
                    myFile = dilog.FileName;
                }
                else
                    return;

                if (Path.GetDirectoryName(myFile) != AppSettings.lastFolder)
                {
                    AppSettings.lastFolder = Path.GetDirectoryName(myFile);
                    AppSettings.WriteIni();
                }
                MemoryStream ms = new MemoryStream();
                using (FileStream fs = new FileStream(myFile, FileMode.Open, FileAccess.Read))
                {
                    fs.CopyTo(ms);
                }

                CutterLoad cut = new CutterLoad();
                dtLen = cut.Load(ms);
                if (dtLen == null) return;

                List<ArtiklsSettings> lstArt = cut.GetArt(dtLen);


                dwGrid.DataSource = dtLen;
                dwGrid.Update();

                _sourceArt.DataSource = lstArt;
                dwArtiklsData.DataSource = _sourceArt;
                #region Set Column Names 
                dwArtiklsData.Columns[1].HeaderText = "Artikl";
                dwArtiklsData.Columns[1].HeaderText = "Length";
                dwArtiklsData.Columns[1].ReadOnly = true;
                dwArtiklsData.Columns[2].HeaderText = "Profile Length";
                dwArtiklsData.Columns[2 + 1].HeaderText = "Amount";
                dwArtiklsData.Columns[2 + 1].ReadOnly = true;                
                #endregion 

                dwArtiklsData.AllowUserToDeleteRows = true;
                dwArtiklsData.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void FormCutter_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.cmdSetLeng, TTR("Set Profile Length for all selected rows"));
        }

        /// <summary>
        /// Set profile lenght 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSetAll_Click(object sender, EventArgs e)
        {            
            //flex artikls           
            if (dwArtiklsData.SelectedRows.Count == 1)
                foreach (DataGridViewRow row in dwArtiklsData.Rows)
                {
                    if (row.IsNewRow == false)
                      row.Cells[2].Value =Convert.ToInt32( numLen.Value);

                }
            else
                foreach (DataGridViewRow row in dwArtiklsData.SelectedRows)
                {
                    if (row.IsNewRow == false)
                        row.Cells[2].Value = Convert.ToInt32 (numLen.Value);
               }
            dwArtiklsData.Update();
        }

        /// <summary>
        /// Main Cutting
        /// </summary>
        private void cmdCutt_Click(object sender, EventArgs e)
        {           
            lblInfo.Text = ""; // Clear log 
            string folderName= @"";
            cuttList = new List<resCut>();


            try
            {
                AppSettings.loadSettingsIni();

                /// Combine all data from artikl

                foreach (DataGridViewRow row in dwArtiklsData.Rows)
                {
                    ArtiklsSettings a = new ArtiklsSettings();
                    a.Art = row.Cells[0].Value.ToString();
                    a.ProfileLength = Convert.ToInt32(row.Cells[2].Value);
                    if  (a.ProfileLength==0 ) {
                        MessageBox.Show(TTR ( "Attention Artikl " + a.Art + " does not have Profile Lenght"), "Error");
                        return;
                    }

                    if (a.Art.Length > 1)
                    { 
                        CuttingPlan cutt =  CreateCuttingload(a, dtLen, folderName);

                        row.Cells[3].Value = cutt ==null ? -1 : cutt.UsedBars;
                        cuttList.Add ( new resCut ( cutt , a));
                   }

                }

                //       Step 2 Set ProfileLength dwCutt
                ShowList();
            }


            

            catch (Exception ex)
            {
                lblInfo.Text += ex.Message;
            }
        }



        internal   void ShowList()
        {
            int nn = 1; // index of strings 
            List <CuttingResult> lcR = new List<CuttingResult>();

            foreach (resCut cuttS in cuttList)
            {
                string art = cuttS.artSettl.Art;
                var  ProfileLength = cuttS.artSettl.ProfileLength;
                var lstString = Reporter.CreateReportTextStrings(cuttS.cutt, AppSettings.SumEqualSegment );

                var groupedLst = lstString
                     .GroupBy(s => s)
                     .Select(g => new { Symbol = g.Key, Count = g.Count() });

                foreach (var elem in groupedLst)
                {
                   CuttingResult res = new CuttingResult();
                    res.N = nn;nn++;
                    res.Artikl = art;
                    res.ProfileLenght = (int)ProfileLength;
                    res.Count= elem.Count ;
                    
                    res.MapOfCutting = elem.Symbol.Substring (0, elem.Symbol.IndexOf("(")).Trim();

                    var numbers = Regex.Matches(elem.Symbol, @"[0-9]+(?:\,[0-9]+)?")
                          .Cast<Match>()
                          .Select(m => m.Value)
                          .ToList();

                    decimal xx = -1;
                    Decimal.TryParse(   numbers.Last() ,out xx);
                    res.Remainder = xx;
                    lcR.Add(res);
                }

            }

            tabControlPage.SelectedTab = tabControlPage.TabPages[1]; 
            dwCutt.DataSource = lcR;


        }

      
        private CuttingPlan CreateCuttingload(ArtiklsSettings a, DataTable dt , string folderName )
        {
            try {
     
                  // Generate list of profiles for cutt
                var lst = dt.AsEnumerable().Where(x=> (x.Field<object>("Artikl").ToString()  == a.Art )).ToList(); //  .Select("Артикул = '" + a.Art + "' " ).ToList();
                if (lst.Count == 0)
                {
                    lblInfo.Text += "Not Found "  + a.Art  + Environment.NewLine + Environment.NewLine;
                    return null;
                }


                int maxLen = 0;
                int ml = 0;
                List<double> lstLen = new List<double>();
                List<int> lstCnt = new List<int>();

                foreach (DataRow dr in lst)
                {
                    lstCnt.Add(Convert.ToInt32(dr["Count"]));
                    lstLen.Add(Convert.ToDouble(dr["Len"]));
                    maxLen =(int)a.ProfileLength;

                }

                ///// We use *10   and int because  need 0.1 accuracy
                CClass cc = new CClass();
                cc.waste = Convert.ToInt32(numericUpDown1.Value)*10;
                cc.maxLength = maxLen*10;

                cc.lengths = lstLen.m10arr();
                cc.amounts = lstCnt.ToArray();

                // Cutting Process 
                CuttingPlan cutt = R_GenerateCuttingScheme(cc);

                protokol++;

                return cutt;

            }
            catch (Exception ex)
            { 
                lblInfo.Text +="Error " + a.Art +" " + " - " + ex.Message;
                //
                return null;
            }
        }


   

        // Main Cutting  - call Library 
        private CuttingPlan  R_GenerateCuttingScheme(CClass cc)
        {
            //Execute Best Fit Heurisitic
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            stopwatch = System.Diagnostics.Stopwatch.StartNew();
            CuttingPlan cpBF = Heuristics.BestFitDecreasing(cc.lengths, cc.amounts, cc.waste, cc.maxLength);
            stopwatch.Stop();
            long elapsedMsBF = stopwatch.ElapsedMilliseconds;
            return cpBF;
        }


        /// <summary>
        /// delete rows Grid 1 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDelete1_Click(object sender, EventArgs e)
        {
            try
            {
                if  (tabControlPage.SelectedTab.Name == "tabPageArt")
                {
                    if (dwGrid.SelectedRows.Count == 1)

                    {
                        dwGrid.Rows.RemoveAt(dwGrid.CurrentRow.Index);

                    }
                    else
                        foreach (DataGridViewRow row in dwGrid.SelectedRows)
                        {
                            dwGrid.Rows.RemoveAt(row.Index);
                        }
                    dwGrid.Update();
                }

       
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + Environment.NewLine + ex.Message);
            }
        }

        private void cmdDelete2_Click(object sender, EventArgs e)
        {
            try
            {
               
                    if (dwArtiklsData.SelectedRows.Count == 1)

                    {
                        dwArtiklsData.Rows.RemoveAt(dwArtiklsData.CurrentRow.Index);

                    }
                    else
                        foreach (DataGridViewRow row in dwArtiklsData.SelectedRows)
                        {
                            dwArtiklsData.Rows.RemoveAt(row.Index);
                        }
                    dwArtiklsData.Update();
            


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + Environment.NewLine + ex.Message);
            }
        }


        //Generate xls
        private void btnXLS_Click(object sender, EventArgs e)
        {try
            {
                if (cuttList.Count > 0)
                {
                    Reporter.GenerateReport(cuttList);
                }
                else
                {
                    MessageBox.Show("You need make Cuttig at first !");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AppSettings.SumEqualSegment = checkBox1.Checked;
                AppSettings.WriteIni();
            }
            catch  { }

        }

        private void cmdAbout_Click(object sender, EventArgs e)
        {

            AboutBox f = new AboutBox();
            f.ShowDialog();
        }



        //Easyest localization 
        private void SetLanguageRU()
        {
            if (AppSettings.language.Contains("Ru"))
            {
                cmdLoad.Text = "Загрузить файл";
                cmdCutt.Text = "Раскрой";
                btnXLS.Text = "Excel выгрузка";

                cmdDelete1.Text = "Удалить строку";
                cmdDelete2.Text = "Удалить строку";
                cmdAbout.Text = "О программе";

                label3.Text = "ширина реза";
                checkBox1.Text = "Суммировать отрезки";
                cmdSetLeng.Text = "Установить длину " + Environment.NewLine + "профиля";
                label4.Text = "Профили";
                tabPage2.Text = "Результаты раскроя";
                tabPageArt.Text = "Спецификация артикулов";
            }

        }

        private string TTR(string v)
        {
            if (!AppSettings.language.Contains("Ru"))
                return v;

            v = v.Replace("Attention Artikl ", "Внимание артикул");
            v = v.Replace("does not have Profile Lenght ", "не имеет указанной длины профиля");

            v = v.Replace("Set Profile Length for all selected rows", "Указывает длину профиля для выделенных строк");
            return v;
            //"Attention Artikl " + a.Art + " does not have Profile Lenght"
        }

    }
}
