using BPD.FATCA.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace BPD.FATCA.Procesor
{
   public class CSVFATCADataProvider : IFATCADataProvider
    {

        private readonly IAppConfiguration _appConfiguration;
        private readonly IApplicationLog applicationLog;

        public CSVFATCADataProvider(IAppConfiguration appConfiguration, IApplicationLog applicationLog)
        {
            _appConfiguration = appConfiguration;
            this.applicationLog = applicationLog;
        }


        List<string> FATCAData = new List<string>();

        public IEnumerable<string[]> GetFATCAData()
        {
            List<string[]> FATCAData = new List<string[]>();

            var path = _appConfiguration.SourceFilesDirectory;


            System.IO.DirectoryInfo Dinfo = new DirectoryInfo(path);

            var filesinDirectory = Dinfo.GetFiles("*.csv");

            if (filesinDirectory.Count() > 0)
            {
                using (TextFieldParser csvParser = new TextFieldParser(filesinDirectory[0].FullName))
                {
                    csvParser.CommentTokens = new string[] { "#" };
                    csvParser.SetDelimiters(new string[] { "," });
                    csvParser.HasFieldsEnclosedInQuotes = true;

                    // Skip the row with the column names
                    // csvParser.ReadLine();

                    while (!csvParser.EndOfData)
                    {
                        // Read current line fields, pointer moves to the next line.                    
                        FATCAData.Add(csvParser.ReadFields());
                    }
                }
               

                if(FATCAData.Count==0)
                {
                    applicationLog.LogMessage($"No se encontraron Datos en el archivo{filesinDirectory[0].FullName}");
                }
                else
                {
                    applicationLog.LogMessage($"Se ha encontrado el archivo {filesinDirectory[0].FullName} con {FATCAData.Count} registros");
                }

                filesinDirectory[0].Delete();


            }
             else
            {
                applicationLog.LogMessage("No se encontraron archivos en la carpeta de Origen");
            }

            return FATCAData;
        }
    }
}
