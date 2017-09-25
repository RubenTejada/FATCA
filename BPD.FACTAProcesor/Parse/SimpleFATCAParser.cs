using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPD.FATCA.Interfaces;


namespace BPD.FATCA.Procesor
{
    public class SimpleFATCAParser : IFATCAParser
    {

        private readonly IFATCAValidator FATCAValidator;
        private readonly IFATCAMapper FATCAMapper;
        private readonly IApplicationLog applicationLog;

        public SimpleFATCAParser(IFATCAValidator FATCAValidator, IFATCAMapper FATCAMapper, IApplicationLog applicationLog)
        {
            if (FATCAValidator == null)
                throw new ArgumentNullException("IFATCAValidator null reference");

            if (FATCAMapper == null)
                throw new ArgumentNullException("IFATCAMapper null reference");


            this.FATCAValidator = FATCAValidator;
            this.FATCAMapper = FATCAMapper;
            this.applicationLog = applicationLog;
        }

        public FATCA_OECD ParseData(IEnumerable<string[]> FATCAData)
        {
            FATCA_OECD FATCAObj = new FATCA_OECD();

            int line = 0;
            bool errorsInFile = false;

            foreach (var item in FATCAData)
            {
                line++;

                try
                {

                    if (FATCAValidator.Validate(item))
                    {
                        FATCAMapper.Map(item, ref FATCAObj);
                    }

                }
                catch (Exception ex)
                {
                    applicationLog.LogError(ex, $"Error en la linea:{line}");
                    errorsInFile = true;
                }

            }

            if (errorsInFile)
                throw new ArgumentException("Se han encontrado errores en el archivo, revise el Log del proceso");


            return FATCAObj;
        }
    }
}
