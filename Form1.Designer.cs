namespace WebCrawler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startCrawlBtn = new System.Windows.Forms.Button();
            this.searchTxtBox = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.keywordListBox = new System.Windows.Forms.ListBox();
            this.visitedLinksListBox = new System.Windows.Forms.ListBox();
            this.keywordLbl = new System.Windows.Forms.Label();
            this.visitedLinksLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startCrawlBtn
            // 
            this.startCrawlBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.startCrawlBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.startCrawlBtn.Location = new System.Drawing.Point(79, 67);
            this.startCrawlBtn.Name = "startCrawlBtn";
            this.startCrawlBtn.Size = new System.Drawing.Size(135, 43);
            this.startCrawlBtn.TabIndex = 0;
            this.startCrawlBtn.Text = "Start Crawl";
            this.startCrawlBtn.UseVisualStyleBackColor = false;
            this.startCrawlBtn.Click += new System.EventHandler(this.startCrawlBtn_Click);
            // 
            // searchTxtBox
            // 
            this.searchTxtBox.Location = new System.Drawing.Point(290, 73);
            this.searchTxtBox.Name = "searchTxtBox";
            this.searchTxtBox.Size = new System.Drawing.Size(150, 31);
            this.searchTxtBox.TabIndex = 1;
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.searchBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.searchBtn.Location = new System.Drawing.Point(537, 67);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(135, 43);
            this.searchBtn.TabIndex = 0;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // keywordListBox
            // 
            this.keywordListBox.FormattingEnabled = true;
            this.keywordListBox.ItemHeight = 25;
            this.keywordListBox.Location = new System.Drawing.Point(31, 184);
            this.keywordListBox.Name = "keywordListBox";
            this.keywordListBox.Size = new System.Drawing.Size(497, 379);
            this.keywordListBox.TabIndex = 2;
            this.keywordListBox.SelectedIndexChanged += new System.EventHandler(this.keywordListBox_SelectedIndexChanged);
            // 
            // visitedLinksListBox
            // 
            this.visitedLinksListBox.FormattingEnabled = true;
            this.visitedLinksListBox.ItemHeight = 25;
            this.visitedLinksListBox.Location = new System.Drawing.Point(625, 184);
            this.visitedLinksListBox.Name = "visitedLinksListBox";
            this.visitedLinksListBox.Size = new System.Drawing.Size(497, 379);
            this.visitedLinksListBox.TabIndex = 2;
            this.visitedLinksListBox.SelectedIndexChanged += new System.EventHandler(this.visitedLinksListBox_SelectedIndexChanged);
            // 
            // keywordLbl
            // 
            this.keywordLbl.AutoSize = true;
            this.keywordLbl.Location = new System.Drawing.Point(31, 145);
            this.keywordLbl.Name = "keywordLbl";
            this.keywordLbl.Size = new System.Drawing.Size(146, 25);
            this.keywordLbl.TabIndex = 3;
            this.keywordLbl.Text = "Search Keywords";
            // 
            // visitedLinksLbl
            // 
            this.visitedLinksLbl.AutoSize = true;
            this.visitedLinksLbl.Location = new System.Drawing.Point(625, 145);
            this.visitedLinksLbl.Name = "visitedLinksLbl";
            this.visitedLinksLbl.Size = new System.Drawing.Size(109, 25);
            this.visitedLinksLbl.TabIndex = 3;
            this.visitedLinksLbl.Text = "Visited Links";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 704);
            this.Controls.Add(this.visitedLinksLbl);
            this.Controls.Add(this.keywordLbl);
            this.Controls.Add(this.visitedLinksListBox);
            this.Controls.Add(this.keywordListBox);
            this.Controls.Add(this.searchTxtBox);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.startCrawlBtn);
            this.Name = "Form1";
            this.Text = "Web Crawler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startCrawlBtn;
        private System.Windows.Forms.TextBox searchTxtBox;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.ListBox keywordListBox;
        private System.Windows.Forms.ListBox visitedLinksListBox;
        private System.Windows.Forms.Label keywordLbl;
        private System.Windows.Forms.Label visitedLinksLbl;
    }
}
