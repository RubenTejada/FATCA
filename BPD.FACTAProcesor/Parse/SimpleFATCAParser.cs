using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPD.FATCA.Interfaces;


namespace BPD.FATCA.Procesor
{
  public  class SimpleFATCAParser:IFATCAParser
    {

      private readonly IFATCAValidator FATCAValidator;
      private readonly IFATCAMapper FATCAMapper;


        public SimpleFATCAParser(IFATCAValidator FATCAValidator, IFATCAMapper FATCAMapper)
        {
            if(FATCAValidator ==null)
                throw new ArgumentNullException("IFATCAValidator null reference");

            if (FATCAMapper == null)
                throw new ArgumentNullException("IFATCAMapper null reference");


            this.FATCAValidator = FATCAValidator;
            this.FATCAMapper = FATCAMapper;
        }

        public FATCA_OECD ParseData(IEnumerable<string> FATCAData)
        {
            FATCA_OECD FATCAObj = new FATCA_OECD();                    
           
            int line = 0;

            foreach (var item in FATCAData)
            {
                line++;

                var fields= item.Split(new char[] {','});

                if(FATCAValidator.Validate(fields))
                {
                    FATCAMapper.Map(fields, ref FATCAObj);
                }

            }

            return FATCAObj;
        }
    }
}
