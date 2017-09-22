using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPD.FATCA.Interfaces
{
    interface IAppConfiguration
    {
        string SourceFilesDirectory { get; set; }
        string DestinationFilesDirectory { get; set; }
        string XSDFilesDirectory { get; set; }
    }
}
