using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace WebCrawler
{
    public class Crawl
    {
        private readonly WebClient client = new WebClient();

        public void GetData()
        {
            Accessor crawler = new Accessor();
            crawler.LinksQueue.Add(crawler.RootSite + "index.html");
            //While LinksQueue is not empty 
            while (crawler.LinksQueue.Count > 0)
            {
                var link = crawler.LinksQueue[0];
                crawler.LinksQueue.RemoveAt(0);
                //If this link is not in the VisitedLinks list
                if (crawler.VisitedLinks.Contains(link) == false)
                {
                    // Download the web page at that first link
                    crawler.WebPage = client.DownloadString(crawler.Url);
                    Console.WriteLine(crawler.WebPage);
                    // Add the link to VisitedLinks
                    crawler.VisitedLinks.Add(link);
                    // find the title<title> of that page 
                    crawler.Pattern = "<title>(.*?)</title>";
                    Match result = Regex.Match(crawler.WebPage, crawler.Pattern);
                    // Add the title and the link as a pair to the Dictionary.
                    crawler.MyDictionary.Add(crawler.Pattern, link);
                    // Print out the title. If you’re using Visual Studio,
                    // add the title to the listBox that displays the search words
                    // found using .Items.Add
                    

                    crawler.Title = "unknown";
                    if (result.Success)
                    {
                        crawler.Title = result.Groups[1].Value;
                    }
                    Console.WriteLine("Found title: " + crawler.Title);
                }
            }

        }
    }

    }


        

    

