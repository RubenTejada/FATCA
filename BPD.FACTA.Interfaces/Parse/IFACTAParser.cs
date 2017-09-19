using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPD.FACTA.Domain;

namespace BPD.FACTA.Interfaces
{
  public  interface IFACTAParser
    {
        IEnumerable<FACTARecord> ParseData(IEnumerable<string> FACTAData);        
    }
}
