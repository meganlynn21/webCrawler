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

        public void startCrawlBtn_Click(object sender, EventArgs e)
        {
            Accessor crawler = new Accessor();

            crawler.RootSite = "http://citelms.net/Internships/Summer_2018/Fan_Site/";
            crawler.LinksQueue = new List<string>();
            crawler.VisitedLinks = new List<string>();
            crawler.MyDictionary = new Dictionary<string, string>();
            crawler.LinksQueue.Add(crawler.RootSite + "index.html");
            visitedLinksListBox.Visible = false;
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

                    // Find the title of that page 
                    crawler.Pattern = "<title>(.*?)</title>";
                    Match result = Regex.Match(crawler.WebPage, crawler.Pattern);
                    // Add the title and the link as a pair to the Dictionary.
                    string title = "unknown";
                    if (result.Success)
                    {
                        title = result.Groups[1].Value;
                    }

                    keywordListBox.Items.Add(title);

                    crawler.Pattern2 = ("<a href=(.*?)>");
                    Regex findPattern = new Regex(crawler.Pattern2);
                    Match result2 = Regex.Match(crawler.WebPage, crawler.Pattern2);
                    foreach (Match m in findPattern.Matches(crawler.WebPage))
                    {
                        var matchGroup = m.Groups[1].Value;
                        if (matchGroup.Contains("http") || matchGroup.Contains("void") || matchGroup.Contains("pdf"))
                            continue;
                        else
                        {
                            if (m.Success)
                            {
                                title = matchGroup;
                                keywordListBox.Items.Add(matchGroup);
                                crawler.LinksQueue.Add(matchGroup);
                                crawler.VisitedLinks.Add(matchGroup);
                                crawler.MyDictionary.Add(title, link);

                            }
                        }           
                    }

                    foreach (KeyValuePair<string, string> item in crawler.MyDictionary)
                    {
                        string dictionaryValues = item.Key + "=>" + item.Value.ToString();
                        visitedLinksListBox.Items.Add((dictionaryValues));
                    }
                    //GetDictionary(crawler.MyDictionary);
                    //crawler.NewList = new List<string>();

                    //foreach (KeyValuePair<string, string> item in crawler.MyDictionary)
                    //{
                    //    string dictionaryValues = item.Key + "=>" + item.Value.ToString();
                    //    crawler.NewList.Add(dictionaryValues);
                    //}

                    //DictionaryVals(crawler.NewList);

                }

            }

        }
        public string GetDictionary()
        {
            return visitedLinksListBox.Text;
        }

        public void searchBtn_Click(object sender, EventArgs e)
        {
            string dictionaryItems = GetDictionary();
            if (searchTxtBox.Text.Contains(dictionaryItems))
                visitedLinksListBox.Visible = true;
            else
                MessageBox.Show("Value isn't in the dictionary!");
        }

        private void keywordListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void visitedLinksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

