using System;
using System.Xml.Serialization;

namespace Models.XML
{
    [XmlRoot(ElementName = "MediaFiles")]
    public struct MediaFiles
    {
        [XmlElement(ElementName = "MediaFile")]
        public string MediaFile { get; set; }
    }

    [XmlRoot(ElementName = "Linear")]
    public struct Linear
    {
        [XmlElement(ElementName = "Duration")] public DateTime Duration { get; set; }

        [XmlElement(ElementName = "MediaFiles")]
        public MediaFiles MediaFiles { get; set; }

        [XmlElement(ElementName = "TrackingEvents")]
        public object TrackingEvents { get; set; }
    }

    [XmlRoot(ElementName = "Creative")]
    public struct Creative
    {
        [XmlElement(ElementName = "Linear")] public Linear Linear { get; set; }
    }

    [XmlRoot(ElementName = "Creatives")]
    public struct Creatives
    {
        [XmlElement(ElementName = "Creative")] public Creative Creative { get; set; }
    }

    [XmlRoot(ElementName = "InLine")]
    public struct InLine
    {
        [XmlElement(ElementName = "Error")] public object Error { get; set; }

        [XmlElement(ElementName = "Creatives")]
        public Creatives Creatives { get; set; }
    }

    [XmlRoot(ElementName = "Ad")]
    public struct Ad
    {
        [XmlElement(ElementName = "InLine")] public InLine InLine { get; set; }
    }

    [XmlRoot(ElementName = "VAST")]
    public struct VAST_Model
    {
        [XmlElement(ElementName = "Ad")] public Ad Ad { get; set; }

        [XmlAttribute(AttributeName = "xsi")] public string Xsi { get; set; }

        [XmlAttribute(AttributeName = "xsd")] public string Xsd { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public double Version { get; set; }

        [XmlText] public string Text { get; set; }
    }
}