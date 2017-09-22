using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPD.FATCA.Interfaces
{
   public interface IFATCAValidator
    {
        bool Validate(string[] FATCAData);
    }
}
