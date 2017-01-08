using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Rca.AliceXmlCsvConverter
{
    public class Axcc
    {
        UTF7Encoding m_AllowOptionals = new UTF7Encoding(true);
        ArticleGroup m_ArtGrp;

        public Axcc()
        {

        }


        public void ReadXml(string path)
        {
            path = FixXmlErrors(path);

            var xSer = new XmlSerializer(typeof(ArticleGroup));

            var sr = new StreamReader(path);

            m_ArtGrp = (ArticleGroup)xSer.Deserialize(sr);

            sr.Close();
        }

        public void GenerateCsv(string path)
        {
            var sw = new StreamWriter(path, false, m_AllowOptionals);

            //Header schreiben
            sw.WriteLine(
                    "Artikelnummer;"
                    + "Artikelname;"
                    + "Artikelname_eng;"
                    + "Beschreibung_eng;"
                    + "Beschreibung;"
                    + "EAN;"
                    + "EAN_gruppen;"
                    + "Mindestmenge;"
                    + "Hersteller;"
                    + "Warengruppe;"
                    + "Intrastat;"
                    + "Gewicht_gruppen;"
                    + "HEK1;"
                    + "Waehrung;"
                    + "UVP_Brutto;"
                    + "UVP_Waehrung;"
                    + "Bild_gross;"
                    + "Lagerbestand;"
                    + "Tech_Data_Cat"

                    + "Picture2;"  
                    + "Picture21;"
                    + "Picture22;"
                    + "Picture23;"
                    + "Picture24;"
                    + "Picture25;"
                    + "Picture26;"
                    + "Picture27;"
                    + "Picture28;"
                    + "Picture29;"
                    + "Picture210"
                    );

            foreach (var art in m_ArtGrp.Articles)
            {
                string txtQualyfier = "\"";
                string sep = txtQualyfier + ";" + txtQualyfier;

                sw.WriteLine(txtQualyfier
                    + art.Artikelnummer + sep
                    + art.Artikelname.Replace('"', ' ') + sep
                    + art.Artikelname_eng.Replace('"', ' ') + sep
                    + art.Beschreibung_eng.Replace('"', ' ') + sep
                    + art.Beschreibung.Replace('"', ' ') + sep
                    + art.EAN + sep
                    + art.EAN_gruppen + sep
                    + art.Mindestminge + sep
                    + art.Hersteller + sep
                    + art.Warengruppe + sep
                    + art.Intrastat + sep
                    + art.Gewicht_gruppen + sep
                    + art.HEK1 + sep
                    + art.Waehrung + sep
                    + art.UVP_Brutto + sep
                    + art.UVP_waehrung + sep
                    + art.Bild_gross + sep
                    + art.Lagerbestand + sep
                    + art.Tech_Data_Cat + sep

                    + art.Picture2.Picture2 + sep
                    + art.Picture2.Picture21   + sep
                    + art.Picture2.Picture22   + sep
                    + art.Picture2.Picture23   + sep
                    + art.Picture2.Picture24   + sep
                    + art.Picture2.Picture25   + sep
                    + art.Picture2.Picture26   + sep
                    + art.Picture2.Picture27   + sep
                    + art.Picture2.Picture28   + sep
                    + art.Picture2.Picture29   + sep
                    + art.Picture2.Picture210  + txtQualyfier
                    );
            }

            sw.Close();

        }

        public string FixXmlErrors(string path)
        {
            var sr = new StreamReader(path, Encoding.UTF7);
            var sw = new StreamWriter(path + "_FIXED.xml", false, m_AllowOptionals);

            string line;
            int lineNumber = 1;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();

                if (line.Contains('ä'))
                    line = line.Replace("ä", "ae");
                if (line.Contains('ö'))
                    line = line.Replace("ö", "oe");
                if (line.Contains('ü'))
                    line = line.Replace("ü", "ue");

                sw.WriteLine(line);

                lineNumber++;
            }

            sr.Close();
            sw.Close();

            return path + "_FIXED.xml";
        }


        /// <summary>
        /// Only for testing
        /// </summary>
        public void GenDummy()
        {
            m_ArtGrp = new ArticleGroup();

            var art = new Article()
            {
                EAN = "foobar",
                Tech_Data_Cat = "foobar",
                Artikelname = "foobar",
                Beschreibung = "foobar",
                HEK1 = "foobar"
            };

            for (int i = 0; i < 3; i++)
                m_ArtGrp.Articles.Add(art);

            var xSer = new XmlSerializer(typeof(ArticleGroup));

            var sw = new StreamWriter("output.xml");

            xSer.Serialize(sw, m_ArtGrp);

            sw.Close();
        }

    }
}
