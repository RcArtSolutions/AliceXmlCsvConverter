using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Rca.AliceXmlCsvConverter
{
    /// <summary>
    /// Item-Node
    /// </summary>
    [Serializable]
    //[XmlRoot(ElementName = "Item")]
    public class Article
    {
        public string Artikelnummer { get; set; }

        public string Artikelname { get; set; }

        public string Artikelname_eng { get; set; }

        public string Beschreibung_eng { get; set; }

        public string Beschreibung { get; set; }

        public string EAN { get; set; }

        public string EAN_gruppen { get; set; }

        public string Mindestminge { get; set; }

        public string Hersteller { get; set; }

        public string Warengruppe { get; set; }

        public string Intrastat { get; set; }

        public string Gewicht_gruppen { get; set; }

        public string HEK1 { get; set; }

        public string Waehrung { get; set; } //UML

        public string UVP_Brutto { get; set; }

        public string UVP_waehrung { get; set; } //UML

        public string Bild_gross { get; set; }

        public string Lagerbestand { get; set; }

        public string Tech_Data_Cat { get; set; }

        public Picture2Group Picture2 { get; set; }

        public Article()
        {
            Picture2 = new Picture2Group();
        }
    }


    public class Zubehör
    {
        //Array??? ZubehörArtikelnummer
    }

    public class Ersatzteile
    {
        //Array??? ErsatzteileArtikelnummer
    }

    public class Tuningteile
    {
        //Array??? TuningteileArtikelnummer
    }

    public class Tech_Data
    {
        //Array??? Spec_data
    }


    [Serializable]
    public class Picture2Group
    {
        public string Picture2 { get; set; }

        public string Picture21 { get; set; }

        public string Picture22 { get; set; }

        public string Picture23 { get; set; }

        public string Picture24 { get; set; }

        public string Picture25 { get; set; }

        public string Picture26 { get; set; }

        public string Picture27 { get; set; }

        public string Picture28 { get; set; }

        public string Picture29 { get; set; }

        public string Picture210 { get; set; }
    }
}
