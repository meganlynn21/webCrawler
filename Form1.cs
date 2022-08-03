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
        private Accessor crawler = new Accessor();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void startCrawlBtn_Click(object sender, EventArgs e)
        {
           

            crawler.RootSite = "http://citelms.net/Internships/Summer_2018/Fan_Site/";
            crawler.LinksQueue = new List<string>();
            crawler.VisitedLinks = new List<string>();
            crawler.MyDictionary = new Dictionary<string, string>();
            crawler.LinksQueue.Add("index.html");
            //While LinksQueue is not empty 
            while (crawler.LinksQueue.Count > 0)
            {
                var link = crawler.LinksQueue[0];
                crawler.LinksQueue.RemoveAt(0);

                if (crawler.VisitedLinks.Contains(link) == false)
                {
                    // Download the web page at that first link
                    crawler.WebPage = client.DownloadString($"{crawler.RootSite}{link}");
                    Console.WriteLine(crawler.WebPage);
                    // Add the link to VisitedLinks List
                    crawler.VisitedLinks.Add(link);

                    // Find the title of that page using Regex
                    crawler.Pattern = "<title>(.*?)</title>";
                    Match result = Regex.Match(crawler.WebPage, crawler.Pattern);
                    // Add the title and the link as a pair to the Dictionary.
                    string title = "unknown";
                    if (result.Success)
                    {
                        title = result.Groups[1].Value;
                    }

                    keywordListBox.Items.Add(title);
                    if (!crawler.MyDictionary.ContainsKey(title))
                    {
                        crawler.MyDictionary.Add(title.ToLower(), link);
                    }
                    
                    crawler.Pattern2 = ("<a href=\"(.*?)\">");
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
                                // Add keywords to list box and add to linksQueue stack
                                keywordListBox.Items.Add(matchGroup);
                                crawler.LinksQueue.Add(matchGroup);
                            }
                        }
                    }

                }

            }

        }

        public void searchBtn_Click(object sender, EventArgs e)
        {
            string searchTerm = searchTxtBox.Text.ToLower();
            if (crawler.MyDictionary.ContainsKey(searchTerm))
            {
                var url = crawler.MyDictionary[searchTerm];
                visitedLinksListBox.Items.Add(url);
            }

            else
            {
                MessageBox.Show("Link not Found");
            }


        }

        private void keywordListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void visitedLinksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

