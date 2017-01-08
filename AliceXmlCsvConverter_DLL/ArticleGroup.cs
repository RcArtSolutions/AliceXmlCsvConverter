using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Rca.AliceXmlCsvConverter
{
    [XmlRoot(ElementName = "data")]
    public class ArticleGroup
    {
        public ArticleGroup()
        {
            this.Articles = new List<Article>();
        }

        [XmlElement(ElementName = "Item")]
        public List<Article> Articles { get; set; }
    }
}
