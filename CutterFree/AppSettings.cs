using IniParser;
using IniParser.Model;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace CutterX
{
    public static  class AppSettings 
    {
        public static string lastFolder { get; set; }
        public static string lastFolderOut { get; set; }

        public static bool SumEqualSegment { get; set; }

        public static string language { get; set; }
     


        public static void setDefault()
        { 
        
            lastFolder = string.Empty;
            lastFolderOut = string.Empty;
            SumEqualSegment = false ;
            language = "En";
        }

        public static void loadSettingsIni()
        {
            try
            {
               var  parser = new FileIniDataParser();
#if DEBUG
                IniData data = parser.ReadFile(@"d:\Configuration.ini");

#else
                IniData data = parser.ReadFile("Configuration.ini");
     
#endif
                AppSettings.lastFolder = data["Settings"]["LastFile"];
                AppSettings.language = data["Settings"]["Language"];
            
                if ((language is null ) || ( language =="Ru" ))
                foreach (InputLanguage c in System.Windows.Forms.InputLanguage.InstalledInputLanguages)
                {
                    if (c.Culture.EnglishName.ToString().Contains("Russian"))
                    {
                        language = "Ru";
                    }
                
                }


                AppSettings.lastFolderOut = data["Settings"]["lastFolderOut"];
                AppSettings.SumEqualSegment = data["Reports"]["SumEqualSegment"].ToString() == "1" ? true : false;

            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }




        public static void WriteIni( )
        {
            var parser = new FileIniDataParser();
#if DEBUG
            string pathIni  = (@"d:\Configuration.ini");

#else
             string pathIni  = ("Configuration.ini");
     
#endif

            try
            {

                IniData data = new IniData();
                data["Settings"].AddKey("LastFile",  (AppSettings.lastFolder));
                data["Settings"].AddKey("lastFolderOut", AppSettings.lastFolderOut);
                data["Settings"].AddKey("Language", AppSettings.language);

                data["Reports"].AddKey("SumEqualSegment", AppSettings.SumEqualSegment ? "1" : "0");
           

                parser.WriteFile(pathIni, data);
            }
            catch (Exception ex) { }

        }


    }
}
