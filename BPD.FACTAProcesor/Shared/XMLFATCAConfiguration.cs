using BPD.FATCA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace BPD.FATCA.Procesor
{
   public class XMLFATCAConfiguration : IAppConfiguration
    {        

        public XMLFATCAConfiguration()
        {
            
        }

        public string SourceFilesDirectory{ get =>  ConfigurationManager.AppSettings["SourceFilesDirectory"];}
        
        public string DestinationFilesDirectory { get => ConfigurationManager.AppSettings["DestinationFilesDirectory"];}

        public string XSDFilesDirectory { get => ConfigurationManager.AppSettings["XSDFilesDirectory"]; }
    }
}
