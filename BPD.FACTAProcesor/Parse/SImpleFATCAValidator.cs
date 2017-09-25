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
        private readonly IApplicationLog applicationLog;

        public SImpleFATCAValidator(IApplicationLog applicationLog)
        {
            this.applicationLog = applicationLog;
        }

        public bool Validate(string[] FATCAData)
        {

            bool Valid = true;

            if (FATCAData.Length != 213)
            {
                Valid = false;
                throw new ArgumentException("Error en la estructura del archivo, la cantidad de campos debe ser de 213");                        
            }


            return Valid;
        }
    }
}
