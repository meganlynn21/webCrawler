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
        public void getData()
        {
            Accessor crawler = new Accessor();
            crawler.LinksQueue.Add(crawler.RootSite + "index.html");
            //While LinksQueue is not empty (check its Count or length to determine this)
            while (crawler.LinksQueue.Count > 0)
            {
                //var firstLink = crawler.LinksQueue[0];
                crawler.LinksQueue.RemoveAt(0);
            }
            /*If this link is not in the VisitedLinks list (use Contains in C#/Java, includes in JavaScript, not in in Python)
            Download the web page at that first link (see starter code above that reads in the file/url).
            Add the link to VisitedLinks
            Using starter code programs as a guide, find the title <title> of that page and Add the title and the link as a pair to the Dictionary. Print out the title. If you’re using Visual Studio,  add the title to the listBox that displays the search words found using .Items.Add. 
            */
            if(crawler.VisitedLinks)
        }

    }
        
}
    

