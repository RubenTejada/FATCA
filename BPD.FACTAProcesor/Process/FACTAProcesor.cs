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

        private readonly IFACTADataProvider FACTADataProvider;
        private readonly IFACTAParser FACTAParser;
        private readonly IFACTAFileGenerator FACTAFileGenerator;

        public FACTAProcesor(IFACTADataProvider FACTADataProvider, IFACTAParser FACTAParser, IFACTAFileGenerator FACTAFileGenerator)
        {
            if (FACTADataProvider == null)
                throw new ArgumentNullException("IFACTADataProvider null reference");

            if (FACTAParser == null)
                throw new ArgumentNullException("IFACTAParser null reference");

            if (FACTAFileGenerator == null)
                throw new ArgumentNullException("IFACTAFileGenerator null reference");

            this.FACTADataProvider = FACTADataProvider;
            this.FACTAParser = FACTAParser;
            this.FACTAFileGenerator = FACTAFileGenerator;
        }

        public void ProcessFACTA()
        {
            var FACTData = FACTADataProvider.GetFACTAData();
            var FACTRecords = FACTAParser.ParseData(FACTData);
            FACTAFileGenerator.GenerateFile(FACTRecords);
        }

    }
}
