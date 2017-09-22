using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BPD.FATCA.Interfaces;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace BPD.FATCA.Procesor.FileGeneration
{
    public class FATCAXMLGenerator : IFATCAFileGenerator
    {
        public void GenerateFile(FATCA_OECD fatcaData)
        {
            XmlSerializer xser = new XmlSerializer(typeof(FATCA_OECD));
           

            using (StreamWriter s = new StreamWriter(@"C:\FATCA\FATCA.xml"))
            {
                xser.Serialize(s, fatcaData);
            }
                
        }
    }
}
