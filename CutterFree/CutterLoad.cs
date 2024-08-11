using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using ExcelDataReader;
using System.IO;
using System.Windows.Forms;


namespace CutterX
{
    internal class CutterLoad
    {
          private BindingSource _source = new BindingSource();
        public CutterLoad()
        { 
        }
        public DataTable Load(Stream stream)
        {
            try
            {
               // IExcelDataReader reader2 = ExcelReaderFactory.CreateBinaryReader(stream);
                IExcelDataReader reader2 = ExcelReaderFactory.CreateReader(stream);

                var result = reader2.AsDataSet(new ExcelDataSetConfiguration
                {

                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = false
                    }
                });

                DataTable dt = result.Tables[0];
                /// 1 - Artikl
                /// 2 - Len                
                /// 3-  Count
                /// 

                ///
                string query = "";
                query = "Column0 is not null and Column1  is not null  and Column2 is not null";//

                var x = dt.Select(query).Where(xx=> xx["Column1"].ToString().Any(Char.IsNumber)  ).Where(xx => xx["Column2"].ToString().Any(Char.IsNumber)).CopyToDataTable(); ;

                DataTable resultDT = FormatterDT(x);
                 return resultDT;

            } catch (Exception ex)
            {
                MessageBox.Show("Error " + Environment.NewLine + ex.Message);
                return null;
            }
        }


        // Group spec  to art/Count 
        internal List<ArtiklsSettings> GetArt(DataTable dt)
        {
            List<ArtiklsSettings>lst = new List<ArtiklsSettings>();

            var query = dt.AsEnumerable()
            .GroupBy(x => new
            {
                s1 = x[0].ToString()
            })
            .Select(grp => new {
                art = grp.Key.s1,
                sum = grp.Sum(r => r.Field<double>("Count") * r.Field<double>("Len"))
            });

            foreach (var grp in query)
            {
                ArtiklsSettings a = new ArtiklsSettings();
                a.Art = grp.art;             
                a.Length = Convert.ToInt32( grp.sum/1000.0);
                lst.Add (a);
            }

            return lst;
        }



        // Set Column names 
        private DataTable FormatterDT(DataTable dt)
        {
            try
            {
                dt.Columns[0].ColumnName = "Artikl";
                dt.Columns[1].ColumnName = "Len";
                dt.Columns[2].ColumnName = "Count";


                DataView view = new DataView(dt);
                DataTable table2 = view.ToTable(false, "Artikl", "Len", "Count" );


                return table2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
    }
}
