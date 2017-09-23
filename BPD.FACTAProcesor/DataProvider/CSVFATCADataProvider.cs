using BPD.FATCA.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPD.FATCA.Procesor
{
   public class CSVFATCADataProvider : IFATCADataProvider
    {

        private readonly IAppConfiguration _appConfiguration;

        public CSVFATCADataProvider(IAppConfiguration appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }


        List<string> FATCAData = new List<string>();

        public IEnumerable<string> GetFATCAData()
        {
            using (var reader = new StreamReader(@"C:\FATCA\A.csv"))
            {                              
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    FATCAData.Add(line);                   
                }
            }

            return FATCAData;
        }
    }
}
