using System;
using System.Xml;
using System.IO;
using System.Reflection;


namespace ZXMAK2.Hardware.Circuits.Ata
{
    public class AtaDeviceInfo
    {
        private const string DefaultSerial = "00000000001234567890";
        private const string DefaultModel = "ZXMAK2 HDD IMAGE";
        
        public string FileName { get; private set; }
        public uint Cylinders { get; private set; }
        public uint Heads { get; private set; }
        public uint Sectors { get; private set; }
        public uint Lba { get; private set; }
        public bool ReadOnly { get; private set; }
        public bool IsCdrom { get; private set; }

        public string SerialNumber { get; private set; }        // 20 chars
        public string FirmwareRevision { get; private set; }    // 8 chars
        public string ModelNumber { get; private set; }         // 40 chars

        
        public AtaDeviceInfo()
        {
            Cylinders = 20; 
            Heads = 16;
            Sectors = 63; 
            Lba = 20160;
            ReadOnly = true;
            IsCdrom = false;
            SerialNumber = DefaultSerial;
            FirmwareRevision = GetVersion();
            ModelNumber = DefaultModel;
        }
        

        public void SaveMaster(string fileName)
        {
            XmlDocument xml = new XmlDocument();
            XmlNode root = xml.AppendChild(xml.CreateElement("IdeDiskDescriptor"));
            XmlNode imageNodeMaster = root.AppendChild(xml.CreateElement("ImageMaster"));
            string imageFile = FileName ?? string.Empty;
            if (imageFile != string.Empty &&
                Path.GetDirectoryName(imageFile) == Path.GetDirectoryName(fileName))
            {
                imageFile = Path.GetFileName(imageFile);
            }
            Utils.SetXmlAttribute(imageNodeMaster, "fileName", imageFile);
            Utils.SetXmlAttribute(imageNodeMaster, "isReadOnly", ReadOnly);
            Utils.SetXmlAttribute(imageNodeMaster, "isCdrom", IsCdrom);
            Utils.SetXmlAttribute(imageNodeMaster, "serial", SerialNumber);
            Utils.SetXmlAttribute(imageNodeMaster, "revision", FirmwareRevision);
            Utils.SetXmlAttribute(imageNodeMaster, "model", ModelNumber);
            XmlNode geometryNodeMaster = root.AppendChild(xml.CreateElement("Geometry"));
            Utils.SetXmlAttribute(geometryNodeMaster, "cylinders", Cylinders);
            Utils.SetXmlAttribute(geometryNodeMaster, "heads", Heads);
            Utils.SetXmlAttribute(geometryNodeMaster, "sectors", Sectors);
            Utils.SetXmlAttribute(geometryNodeMaster, "lba", Lba);
            xml.Save(fileName);
        }

        public void SaveSlave(string fileName)
        {
            XmlDocument xml = new XmlDocument();
            XmlNode root = xml.AppendChild(xml.CreateElement("IdeDiskDescriptor"));
            XmlNode imageNodeSlave = root.AppendChild(xml.CreateElement("ImageSlave"));
            string imageFile = FileName ?? string.Empty;
            if (imageFile != string.Empty &&
                Path.GetDirectoryName(imageFile) == Path.GetDirectoryName(fileName))
            {
                imageFile = Path.GetFileName(imageFile);
            }
            Utils.SetXmlAttribute(imageNodeSlave, "fileName", imageFile);
            Utils.SetXmlAttribute(imageNodeSlave, "isReadOnly", ReadOnly);
            Utils.SetXmlAttribute(imageNodeSlave, "isCdrom", IsCdrom);
            Utils.SetXmlAttribute(imageNodeSlave, "serial", SerialNumber);
            Utils.SetXmlAttribute(imageNodeSlave, "revision", FirmwareRevision);
            Utils.SetXmlAttribute(imageNodeSlave, "model", ModelNumber);
            XmlNode geometryNodeSlave = root.AppendChild(xml.CreateElement("Geometry"));
            Utils.SetXmlAttribute(geometryNodeSlave, "cylinders", Cylinders);
            Utils.SetXmlAttribute(geometryNodeSlave, "heads", Heads);
            Utils.SetXmlAttribute(geometryNodeSlave, "sectors", Sectors);
            Utils.SetXmlAttribute(geometryNodeSlave, "lba", Lba);
            xml.Save(fileName);
        }

        public void LoadMaster(string fileName)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(fileName);
            XmlNode root = xml["IdeDiskDescriptor"];
            XmlNode imageNodeMaster = root["ImageMaster"];
            XmlNode geometryNodeMaster = root["Geometry"];
            FileName = Utils.GetXmlAttributeAsString(imageNodeMaster, "fileName", FileName ?? string.Empty);
            if (FileName != string.Empty && !Path.IsPathRooted(FileName))
                FileName = Utils.GetFullPathFromRelativePath(FileName, Path.GetDirectoryName(fileName));
            SerialNumber = Utils.GetXmlAttributeAsString(imageNodeMaster, "serial", SerialNumber);
            FirmwareRevision = Utils.GetXmlAttributeAsString(imageNodeMaster, "revision", FirmwareRevision);
            ModelNumber = Utils.GetXmlAttributeAsString(imageNodeMaster, "model", ModelNumber);
            IsCdrom = Utils.GetXmlAttributeAsBool(imageNodeMaster, "isCdrom", false);
            ReadOnly = Utils.GetXmlAttributeAsBool(imageNodeMaster, "isReadOnly", true);
            Cylinders = Utils.GetXmlAttributeAsUInt32(geometryNodeMaster, "cylinders", Cylinders);
            Heads = Utils.GetXmlAttributeAsUInt32(geometryNodeMaster, "heads", Heads);
            Sectors = Utils.GetXmlAttributeAsUInt32(geometryNodeMaster, "sectors", Sectors);
            Lba = Utils.GetXmlAttributeAsUInt32(geometryNodeMaster, "lba", Lba);
        }

        public void LoadSlave(string fileName)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(fileName);
            XmlNode root = xml["IdeDiskDescriptor"];
            XmlNode imageNodeSlave = root["ImageSlave"];
            XmlNode geometryNodeSlave = root["Geometry"];
            FileName = Utils.GetXmlAttributeAsString(imageNodeSlave, "fileName", FileName ?? string.Empty);
            if (FileName != string.Empty && !Path.IsPathRooted(FileName))
                FileName = Utils.GetFullPathFromRelativePath(FileName, Path.GetDirectoryName(fileName));
            SerialNumber = Utils.GetXmlAttributeAsString(imageNodeSlave, "serial", SerialNumber);
            FirmwareRevision = Utils.GetXmlAttributeAsString(imageNodeSlave, "revision", FirmwareRevision);
            ModelNumber = Utils.GetXmlAttributeAsString(imageNodeSlave, "model", ModelNumber);
            IsCdrom = Utils.GetXmlAttributeAsBool(imageNodeSlave, "isCdrom", false);
            ReadOnly = Utils.GetXmlAttributeAsBool(imageNodeSlave, "isReadOnly", true);
            Cylinders = Utils.GetXmlAttributeAsUInt32(geometryNodeSlave, "cylinders", Cylinders);
            Heads = Utils.GetXmlAttributeAsUInt32(geometryNodeSlave, "heads", Heads);
            Sectors = Utils.GetXmlAttributeAsUInt32(geometryNodeSlave, "sectors", Sectors);
            Lba = Utils.GetXmlAttributeAsUInt32(geometryNodeSlave, "lba", Lba);
        }

        private static string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.Revision.ToString();
        }
    }
}
