
using BPD.FATCA.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace BPD.FATCA.Procesor
{
    public class XMLFATCAGenerator : IFATCAFileGenerator
    {
        public void GenerateFile(FATCA_OECD FATCAObj)
        {
            XmlSerializer xser = new XmlSerializer(typeof(FATCA_OECD));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("ftc", "urn:oecd:ties:fatca:v2");
            ns.Add("stf", "urn:oecd:ties:stf:v4");
            ns.Add("sfa", "urn:oecd:ties:stffatcatypes:v2");
            ns.Add("iso", "urn: oecd: ties: isofatcatypes: v1");
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");


            //Sorting Reports By type
            var AccountReport = FATCAObj.FATCA[0].ReportingGroup[0].Items.OfType<CorrectableAccountReport_Type>();
            var NilReport = FATCAObj.FATCA[0].ReportingGroup[0].Items.OfType<CorrectableNilReport_Type>();
            var PoolReport = FATCAObj.FATCA[0].ReportingGroup[0].Items.OfType<CorrectablePoolReport_Type>();

            IEnumerable<object> Reports = new object[0];

            if (AccountReport.Count() > 0 || PoolReport.Count() > 0)
            {
                Reports = AccountReport.Concat<object>(PoolReport);

                FATCAObj.FATCA[0].ReportingGroup[0].Items = Reports.ToArray();

                using (StreamWriter s = new StreamWriter(@"C:\FATCA\Accounts_Pool_Report.xml"))
                {
                    xser.Serialize(s, FATCAObj, ns);
                }

            }
            if (NilReport.Count() > 0)
            {
                Reports = NilReport;

                FATCAObj.FATCA[0].ReportingGroup[0].Items = Reports.ToArray();
                using (StreamWriter s = new StreamWriter(@"C:\FATCA\NilReport.xml"))
                {
                    xser.Serialize(s, FATCAObj, ns);
                }
            }



        }
    }
}
