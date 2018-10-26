using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Data;
using HtmlAgilityPack;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace WebSpider
{


    public partial class WebSpider : Form
    {
        public WebSpider()
        {
            InitializeComponent();
        }

        public static List<string> citylist = new List<string>();//储存城市列表
        public static List<int> totalpages = new List<int>();//储存每一个城市共有多少页
        public static List<stocks> stockInfos = new List<stocks>();//储存所有信息
        public static List<stocks> read_infos = new List<stocks>();

        void getTotalpages_Infos()
        {
            if (citylist.Count == 0)
                return;
            for (int i = 0; i < citylist.Count; i++)
            {
                int pages = 0;
                string cityurl = "https://www.nowcoder.com/recommend-intern/list?token=&page=1&address=" + citylist[i];
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(cityurl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string jsonBar = sr.ReadToEnd();
                sr.Close();
                JObject result = JObject.Parse(jsonBar);
                pages = Convert.ToInt32(result["data"]["totalPage"]);
                totalpages.Add(pages);//添加页数
            }
        }

        void getAll_Infos()
        {
            if (citylist.Count <= 0)
                return;

            for (int i = 0; i < citylist.Count; i++)//每个城市
            {
                result.Text += i + 1 + ".正在爬取" + citylist[i] + "的所有岗位信息" + "\n";
                for (int j = 1; j <= totalpages[i]; j++)//页数
                {
                    string cityurl = "https://www.nowcoder.com/recommend-intern/list?token=&page=" + j + "&address=" + citylist[i];
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(cityurl);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    string jsonBar = sr.ReadToEnd();
                    sr.Close();
                    JObject result = JObject.Parse(jsonBar);
                    IList<JToken> list = result["data"]["jobList"].Children().ToList();
                    foreach (var item in list)//每一页的每一个岗位
                    {
                        stockInfos.Add(read_Single_Info(item));//添加工作岗位
                    }
                }
                result.Text += "爬取成功 " + citylist[i] + "：共有" + totalpages[i] + "页数据" + "\n";
            }
        }

        string RemoveNandT(string str)
        {
            char[] strArr = str.ToCharArray();
            string newStr = "";
            foreach (char cr in strArr)
            {
                if (cr == '\t' || cr == '\n'||cr =='\r')
                {
                    continue;
                }
                newStr += cr.ToString();
            }
            return newStr;
        }

        //得到每一个岗位具体信息
        stocks read_Single_Info(object info)
        {

            JToken item = (JToken)info;
            string companyId = item.Value<string>("internCompanyId");
            string id = item.Value<string>("id");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.nowcoder.com/recommend-intern/" + companyId + "?jobId=" + id);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.GetResponseStream();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string s = sr.ReadToEnd();
            sr.Close();
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(s);


            stocks stock = new stocks();

            //存入名字
            string name = RemoveNandT(htmlDoc.DocumentNode.SelectNodes("//div[@class='rec-job']/h2").First().InnerText);
            stock.setName(name);

            //存入职责
            String duty = "";
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='rec-job']/dl[1]");
            for (int k = 0; k < nodes.Count; k++)
            {
                duty += nodes[k].InnerText;
            }
            string newduty = RemoveNandT(duty);
            stock.setDuty(newduty);

            //存入工作需求
            String requirement = "";
            nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='rec-job']/dl[2]");
            for (int k = 0; k < nodes.Count; k++)
            {
                requirement += nodes[k].InnerText;
            }
            string newrequirement = RemoveNandT(requirement);
            stock.setRecommand(newrequirement);

            //存入工作地
            string place = RemoveNandT(htmlDoc.DocumentNode.SelectNodes("//p[@class='com-lbs']").First().InnerText);
            stock.setPlace(place);

            //存入公司名称
            string companyname = RemoveNandT(htmlDoc.DocumentNode.SelectNodes("//h3[@class='teacher-name']").First().InnerText);
            stock.setcompanyName(companyname);

            //存入公司简介
            string companyintroduction = RemoveNandT(htmlDoc.DocumentNode.SelectNodes("//div[@class='com-detail']/p[1]").First().InnerText);
            stock.setcompanyIntroduction(companyintroduction);
            //存入公司网址
            string companyUrl = "";
            var companyurl = htmlDoc.DocumentNode.SelectNodes("//div[@class='com-detail']/p[last()]/a");
            if (companyurl != null)
            {
                companyUrl = companyurl.First().InnerText;
            }
            string newcompanyUrl = RemoveNandT(companyUrl);
            stock.setcompanyUrl(newcompanyUrl);
            return stock;

        }

        private void button_start_Click(object sender, EventArgs e)
        {
            try
            {
                string url = UrlText.Text;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string s = sr.ReadToEnd();
                sr.Close();
                HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(s);
                var list = htmlDoc.DocumentNode.SelectNodes("//a[@class='js-address']");
                for (int i = 0; i < list.Count; i++)
                {
                    citylist.Add(list[i].InnerText);
                }
                result.Text += "找到了" + citylist.Count + "个城市的岗位信息，准备开始爬取..." + "\n";
                getTotalpages_Infos();
                getAll_Infos();

            }catch(Exception error)
            {
                result.Text += error;
            }


        }

        private void button_save_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath + "\\data.txt";
                if (stockInfos.Count == 0)
                {
                    MessageBox.Show("你还没有开始爬取数据啊，我拿头存。");
                }
                WriteIn(path);
            }
        }

        public void WriteIn(string path)
        {
            if (stockInfos.Count == 0)
            {
                MessageBox.Show("没有数据，略略略");
                return;
            }
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            //开始写入
            sw.Write("Name" + "\t");
            sw.Write("Duty" + "\t");
            sw.Write("Recommand" + "\t");
            sw.Write("Place" + "\t");
            sw.Write("CompanyName" + "\t");
            sw.Write("CompanyIntroduction" + "\t");
            sw.Write("CompanyAdress" + "\n");

            for (int i = 0; i < stockInfos.Count; i++)
            {
                sw.Write(stockInfos[i].getName() + "\t");
                sw.Write(stockInfos[i].getDuty() + "\t");
                sw.Write(stockInfos[i].getRecommand() + "\t");
                sw.Write(stockInfos[i].getPlace() + "\t");
                sw.Write(stockInfos[i].getcompanyName() + "\t");
                sw.Write(stockInfos[i].getcompanyIntroduction() + "\t");
                sw.Write(stockInfos[i].getcompanyUrl() + "\n");
            }

            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
            MessageBox.Show("储存成功!");
        }

        private void Item_read_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openDialog.FileName; ;
                if (!path.EndsWith(".txt"))
                {
                    MessageBox.Show("只能读取正确格式储存的txt文件，略略略");
                    return;

                }
                Readout(path);
            }
        }

        public void Readout(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            string line = sr.ReadLine();
            while ((line = sr.ReadLine()) != null)
            {
                stocks stock = new stocks();
                string[] Sline = line.Split('\t');
                if (Sline.Length > 6)
                {
                    stock.setName(Sline[0]);
                    stock.setDuty(Sline[1]);
                    stock.setRecommand(Sline[2]);
                    stock.setPlace(Sline[3]);
                    stock.setcompanyName(Sline[4]);
                    stock.setcompanyIntroduction(Sline[5]);
                    stock.setcompanyUrl(Sline[6]);
                }
                read_infos.Add(stock);
            }
            MessageBox.Show("读取成功！");
        }

        private void button_show_Click(object sender, EventArgs e)
        {
            if (read_infos.Count == 0)
            {
                MessageBox.Show("你先要导入文件啊，兄弟");
                return;
            }
            showList.Items.Clear();
            for (int i = 0; i < read_infos.Count; i++)
            {

                showList.Items.Add((i + 1) + ".Name: " + read_infos[i].getName() + "\nDuty:" + read_infos[i].getDuty() +
                    "\nRecommand: " + read_infos[i].getRecommand() + "\nPlace: " + read_infos[i].getPlace() +
                    "\nCompanyName: " + read_infos[i].getcompanyName() + "\nCompanyIntroduction: " + read_infos[i].getcompanyIntroduction() +
                    "\nCompanyUrl: " + read_infos[i].getcompanyUrl());
            }
        }

        private void showList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(showList.SelectedItem.ToString());
        }

        private void Item_news_Click(object sender, EventArgs e)
        {

            string url = UrlText.Text;
            result.Text = "准备爬取网站最新消息，并直接展示";
            stockInfos.Clear();
            citylist.Clear();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string s = sr.ReadToEnd();
            sr.Close();
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(s);
            var list = htmlDoc.DocumentNode.SelectNodes("//a[@class='js-address']");
            for (int i = 0; i < list.Count; i++)
            {
                citylist.Add(list[i].InnerText);
            }
            result.Text += "找到了" + citylist.Count + "个城市的岗位信息，准备开始爬取..." + "\n";
            getTotalpages_Infos();
            getAll_Infos();
            showList.Items.Clear();
            for (int i = 0; i < stockInfos.Count; i++)
            {
                showList.Items.Add((i + 1) + ".Name: " + stockInfos[i].getName() + "\nDuty:" + stockInfos[i].getDuty() +
                    "\nRecommand: " + stockInfos[i].getRecommand() + "\nPlace: " + stockInfos[i].getPlace() +
                    "\nCompanyName: " +stockInfos[i].getcompanyName() + "\nCompanyIntroduction: " + stockInfos[i].getcompanyIntroduction() +
                    "\nCompanyUrl: " + stockInfos[i].getcompanyUrl());
            }



        }
    }
}



    public class stocks
    {
        private string name;
        private string duty;
        private string recommand;
        private string place;
        private string companyName;
        private string companyIntroduction;
        private string companyUrl;
        //get
        public string getName()
        {
            return this.name;
        }
        public string getDuty()
        {
            return this.duty;
        }
        public string getRecommand()
        {
            return this.recommand;
        }
        public string getPlace()
        {
            return this.place;
        }
        public string getcompanyName()
        {
            return this.companyName;
        }
        public string getcompanyIntroduction()
        {
            return this.companyIntroduction;
        }
        public string getcompanyUrl()
        {
            return this.companyUrl;
        }
        //set
        public void setcompanyUrl(string str)
        {
            this.companyUrl = str;
        }
        public void setcompanyIntroduction(string str)
        {
            this.companyIntroduction = str;
        }
        public void setcompanyName(string str)
        {
            this.companyName = str;
        }
        public void setPlace(string str)
        {
            this.place = str;
        }
        public void setRecommand(string str)
        {
            this.recommand = str;
        }
        public void setDuty(string str)
        {
            this.duty = str;
        }
        public void setName(string str)
        {
            this.name = str;
        }
    }
