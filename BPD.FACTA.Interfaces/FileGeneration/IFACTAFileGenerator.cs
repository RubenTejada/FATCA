using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BPD.FATCA.Interfaces
{
    public interface IFATCAFileGenerator
    {
       void GenerateFile(FATCA_OECD FATCARecords);
    }
}
