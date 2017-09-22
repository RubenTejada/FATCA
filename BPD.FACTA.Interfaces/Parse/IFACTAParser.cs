using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BPD.FATCA.Interfaces
{
  public  interface IFATCAParser
    {
        FATCA_OECD ParseData(IEnumerable<string> FATCAData);        
    }
}
