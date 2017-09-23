using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPD.FATCA.Domain
{
    public class ColumnIndexAttribute : Attribute
    {
       public int Index { get; private set; }

        public ColumnIndexAttribute(int index)
        {
            this.Index = index;
        }
    }
}
