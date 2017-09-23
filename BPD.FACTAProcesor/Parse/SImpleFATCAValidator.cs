using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPD.FATCA.Interfaces;

namespace BPD.FATCA.Procesor
{
   public class SImpleFATCAValidator : IFATCAValidator
    {
        public SImpleFATCAValidator()
        {
        }

        public bool Validate(string[] FATCAData)
        {

            //TODO: Implementar Validacion

            return true;
        }
    }
}
