namespace WebSpider
{
    partial class WebSpider
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.url = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.RichTextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu_Read = new System.Windows.Forms.ToolStripMenuItem();
            this.Item_read = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_news = new System.Windows.Forms.ToolStripMenuItem();
            this.Item_news = new System.Windows.Forms.ToolStripMenuItem();
            this.showList = new System.Windows.Forms.ListBox();
            this.button_show = new System.Windows.Forms.Button();
            this.UrlText = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // url
            // 
            this.url.AutoSize = true;
            this.url.Location = new System.Drawing.Point(25, 51);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(34, 23);
            this.url.TabIndex = 1;
            this.url.Text = "url";
            // 
            // button_start
            // 
            this.button_start.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.Location = new System.Drawing.Point(517, 49);
            this.button_start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(63, 30);
            this.button_start.TabIndex = 2;
            this.button_start.Text = "start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(29, 90);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(551, 258);
            this.result.TabIndex = 3;
            this.result.Text = "";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(586, 203);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 34);
            this.button_save.TabIndex = 4;
            this.button_save.Text = "save";
            this.button_save.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Read,
            this.menu_news});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(694, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu_Read
            // 
            this.Menu_Read.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Item_read});
            this.Menu_Read.Name = "Menu_Read";
            this.Menu_Read.Size = new System.Drawing.Size(54, 24);
            this.Menu_Read.Text = "read";
            // 
            // Item_read
            // 
            this.Item_read.Name = "Item_read";
            this.Item_read.Size = new System.Drawing.Size(178, 26);
            this.Item_read.Text = "readFromTxt";
            this.Item_read.Click += new System.EventHandler(this.Item_read_Click);
            // 
            // menu_news
            // 
            this.menu_news.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Item_news});
            this.menu_news.Name = "menu_news";
            this.menu_news.Size = new System.Drawing.Size(51, 24);
            this.menu_news.Text = "new";
            // 
            // Item_news
            // 
            this.Item_news.Name = "Item_news";
            this.Item_news.Size = new System.Drawing.Size(179, 26);
            this.Item_news.Text = "getAndShow";
            this.Item_news.Click += new System.EventHandler(this.Item_news_Click);
            // 
            // showList
            // 
            this.showList.FormattingEnabled = true;
            this.showList.ItemHeight = 23;
            this.showList.Location = new System.Drawing.Point(29, 354);
            this.showList.Name = "showList";
            this.showList.Size = new System.Drawing.Size(551, 257);
            this.showList.TabIndex = 6;
            this.showList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.showList_MouseDoubleClick);
            // 
            // button_show
            // 
            this.button_show.Location = new System.Drawing.Point(586, 483);
            this.button_show.Name = "button_show";
            this.button_show.Size = new System.Drawing.Size(75, 34);
            this.button_show.TabIndex = 7;
            this.button_show.Text = "show";
            this.button_show.UseVisualStyleBackColor = true;
            this.button_show.Click += new System.EventHandler(this.button_show_Click);
            // 
            // UrlText
            // 
            this.UrlText.Location = new System.Drawing.Point(65, 48);
            this.UrlText.Name = "UrlText";
            this.UrlText.ReadOnly = true;
            this.UrlText.Size = new System.Drawing.Size(425, 31);
            this.UrlText.TabIndex = 8;
            this.UrlText.Text = "https://www.nowcoder.com/recommend";
            // 
            // WebSpider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 628);
            this.Controls.Add(this.UrlText);
            this.Controls.Add(this.button_show);
            this.Controls.Add(this.showList);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.result);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.url);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "WebSpider";
            this.Text = "WebSpider——powered by victorinox";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label url;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.RichTextBox result;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_news;
        private System.Windows.Forms.ToolStripMenuItem Menu_Read;
        private System.Windows.Forms.ToolStripMenuItem Item_read;
        private System.Windows.Forms.ToolStripMenuItem Item_news;
        private System.Windows.Forms.ListBox showList;
        private System.Windows.Forms.Button button_show;
        private System.Windows.Forms.TextBox UrlText;
    }
}

