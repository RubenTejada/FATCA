using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPD.FATCA.Interfaces;

namespace BPD.FATCA.Procesor
{
  public  class TestFATCADataProvider : IFATCADataProvider
    {
        public IEnumerable<string> GetFATCAData()
        {
            var result = new List<string>();
            result.Add("5WSFNN,99999,SL");
            result.Add("111,222,333");
            result.Add("111,222,333");
            result.Add("111,222,333");

            return result;
        }
    }
}
