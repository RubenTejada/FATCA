using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BPD.FATCA.Interfaces
{
  public  interface IFATCAMapper
    {
        FATCA_OECD Map(string[] FATCAData, ref FATCA_OECD FATCAObj);
    }
}
