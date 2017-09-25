using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BPD.FATCA.Interfaces;

namespace BPD.FATCA.Procesor
{
    public class FATCAProcesor : IFATCAProcesor
    {

        private readonly IFATCADataProvider FATCADataProvider;
        private readonly IFATCAParser FATCAParser;
        private readonly IFATCAFileGenerator FATCAFileGenerator;
        private readonly IApplicationLog applicationLog;

        public FATCAProcesor(IFATCADataProvider FATCADataProvider, IFATCAParser FATCAParser, IFATCAFileGenerator FATCAFileGenerator, IApplicationLog applicationLog)
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
            this.applicationLog = applicationLog;
        }

        public void ProcessFATCA()
        {
            try
            {
           
            var FACTData = FATCADataProvider.GetFATCAData();

            if (FACTData.Count() > 0)
            {
                var FACTRecords = FATCAParser.ParseData(FACTData);
                FATCAFileGenerator.GenerateFile(FACTRecords);
            }

            }
            catch (Exception ex)
            {
                applicationLog.LogError(ex, "Error al procesar archivo");
            }

        }

    }
}
