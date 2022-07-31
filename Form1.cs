using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace WebCrawler
{
    public partial class Form1 : Form
    {
        private readonly WebClient client = new WebClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void startCrawlBtn_Click(object sender, EventArgs e)
        {

            Accessor crawler = new Accessor();

            crawler.RootSite = "http://citelms.net/Internships/Summer_2018/Fan_Site/";
            crawler.LinksQueue = new List<string>();
            crawler.VisitedLinks = new List<string>();
            crawler.MyDictionary = new Dictionary<string, string>();
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
                    crawler.WebPage = client.DownloadString(crawler.RootSite);
                    Console.WriteLine(crawler.WebPage);
                    // Add the link to VisitedLinks
                    crawler.VisitedLinks.Add(link);
                    // find the title<title> of that page 
                    crawler.Pattern = "<title>(.*?)</title>";
                    Match result = Regex.Match(crawler.WebPage, crawler.Pattern);
                    // Add the title and the link as a pair to the Dictionary.
                    string title = "unknown";
                    if (result.Success)
                    {
                        title = result.Groups[1].Value;
                    }
                    //crawler.MyDictionary.Add(title, link);
                    // Print out the title. If you’re using Visual Studio,
                    // add the title to the listBox that displays the search words
                    // found using .Items.Add
                    keywordListBox.Items.Add(title);

                    crawler.Pattern2 = ("<a href=(.*?)>");
                    Regex findPattern = new Regex(crawler.Pattern2);
        
                    foreach (Match m in findPattern.Matches(crawler.WebPage))
                    {
                        var matchGroup = m.Groups[1].Value;
                        if (matchGroup.Contains("http") || matchGroup.Contains("void") || matchGroup.Contains("pdf"))
                            continue;
                        else
                        {
                            if (m.Success)
                            {
                                keywordListBox.Items.Add(matchGroup);
                                crawler.LinksQueue.Add(matchGroup);
                                crawler.VisitedLinks.Add(matchGroup);
                            }
                        }
                       
                           
                    }

                }

            }

        }


        private void searchBtn_Click(object sender, EventArgs e)
        {

        }

        private void keywordListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void visitedLinksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

