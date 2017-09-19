using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPD.FACTA.Interfaces;
using BPD.FACTA.Domain;

namespace BPD.FACTA.Procesor
{
  public  class SimpleFACTAParser:IFACTAParser
    {

      private readonly IFACTAValidator FACTAValidator;
      private readonly IFACTAMapper FACTAMapper;


        public SimpleFACTAParser(IFACTAValidator FACTAValidator, IFACTAMapper FACTAMapper)
        {
            this.FACTAValidator = FACTAValidator;
            this.FACTAMapper = FACTAMapper;
        }

        public IEnumerable<FACTARecord> ParseData(IEnumerable<string> FACTAData)
        {
            
            var result = new List<FACTARecord>();
            int line = 0;

            foreach (var item in FACTAData)
            {
                line++;

                var fields= item.Split(new char[] {','});

                if (FACTAValidator.Validate(fields))
                    result.Add(FACTAMapper.Map(fields));

            }


            return result;
        }
    }
}
