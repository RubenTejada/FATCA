using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BPD.FATCA.Interfaces;

namespace BPD.FATCA.Procesor
{
    public class FATCAProcesor
    {

        private readonly IFATCADataProvider FATCADataProvider;
        private readonly IFATCAParser FATCAParser;
        private readonly IFATCAFileGenerator FATCAFileGenerator;

        public FATCAProcesor(IFATCADataProvider FATCADataProvider, IFATCAParser FATCAParser, IFATCAFileGenerator FATCAFileGenerator)
        {
            if (FATCADataProvider == null)
                throw new ArgumentNullException("IFATCADataProvider null reference");

            if (FATCAParser == null)
                throw new ArgumentNullException("IFATCAParser null reference");

            if (FATCAFileGenerator == null)
                throw new ArgumentNullException("IFATCAFileGenerator null reference");

            this.FATCADataProvider = FATCADataProvider;
            this.FATCAParser = FATCAParser;
            this.FATCAFileGenerator = FATCAFileGenerator;
        }

        public void ProcessFATCA()
        {
            var FACTData = FATCADataProvider.GetFATCAData();
            var FACTRecords = FATCAParser.ParseData(FACTData);
            FATCAFileGenerator.GenerateFile(FACTRecords);
        }

    }
}
