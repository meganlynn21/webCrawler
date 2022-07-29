using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
namespace WebCrawler
{
    internal class Website
    {
        private readonly WebClient client = new WebClient(); // needs using System.Net;
        public void SetData()
        {
            Accessor data = new Accessor();
            data.RootSite = "http://citelms.net/Internships/Summer_2018/Fan_Site/";
            data.Url = "http://www.elms.edu";
            data.WebPage = client.DownloadString(data.Url);
            Console.WriteLine(data.WebPage);
            data.Pattern = "<title>(.*?)</title>";

            // needs using System.Text.RegularExpressions;
            Match result = Regex.Match(data.WebPage, data.Pattern);
            data.Title = "unknown";
            if (result.Success)
            {
                data.Title = result.Groups[1].Value;
            }
            Console.WriteLine("Found title: " + data.Title);
        }
    }
}

