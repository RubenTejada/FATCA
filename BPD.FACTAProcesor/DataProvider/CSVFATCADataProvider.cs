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

        public CSVFATCADataProvider()
        {
           
        }


        List<string> FATCAData = new List<string>();

        public IEnumerable<string[]> GetFATCAData()
        {
            List<string[]> FATCAData = new List<string[]>();

            var path = @"C:\FATCA\Total.csv"; 
            using (TextFieldParser csvParser = new TextFieldParser(path))
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

            return FATCAData;
        }
    }
}
