using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPD.FACTA.Interfaces
{
   public interface IFACTAValidator
    {
        bool Validate(IEnumerable<string> FACTAData);
    }
}
