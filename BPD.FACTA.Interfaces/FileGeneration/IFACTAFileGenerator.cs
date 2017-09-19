using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPD.FACTA.Domain;

namespace BPD.FACTA.Interfaces
{
    public interface IFACTAFileGenerator
    {
       void GenerateFile(IEnumerable<FACTARecord> factaRecords);
    }
}
