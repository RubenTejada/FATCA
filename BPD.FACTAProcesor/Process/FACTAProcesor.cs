using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPD.FACTA.Domain;
using BPD.FACTA.Interfaces;

namespace BPD.FACTA.Procesor
{
    public class FACTAProcesor
    {

        private readonly IFACTADataProvider factaDataProvider;
        private readonly IFACTAParser factaParser;
        private readonly IFACTAFileGenerator factaFileGenerator;

        public FACTAProcesor(IFACTADataProvider factaDataProvider, IFACTAParser factaParser, IFACTAFileGenerator factaFileGenerator)
        {
            this.factaDataProvider = factaDataProvider;
            this.factaParser = factaParser;
            this.factaFileGenerator = factaFileGenerator;
        }

        public void ProcessFACTA()
        {
            var FACTData = factaDataProvider.GetFACTAData();
            var FACTRecords = factaParser.ParseData(FACTData);
            factaFileGenerator.GenerateFile(FACTRecords);
        }

    }
}
