using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
namespace WebCrawler
{ 
    public class Accessor
    { 
        public string Url
        {
            get { return Url; }
            set { Url = "http://www.elms.edu"; }
        }
        public string WebPage { get; set; }
        public string Pattern { get; set; }
        public string Title { get; set; }
        public string RootSite { get; set; }
        public List<string> LinksQueue { get; set; }
        public List<string> VisitedLinks { get; set; }
        public Dictionary<string, string> HashTable { get; set; }


    }
}
