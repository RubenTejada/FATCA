using System.Xml.Serialization;

public partial class FATCA_OECD
{

    [XmlAttributeAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string xsiSchemaLocation = "urn:oecd:ties:fatca:v2 FatcaXML_v2.0.xsd";

}