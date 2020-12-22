using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace project_window
{
    public partial class setting : Form
    {
        Program pr=new Program();
        public setting()
        {
            pr.initChrome();
            InitializeComponent();
            //this.BackgroundImage = Image.FromFile(@"C:\Users\17290\Desktop\project_window\background.jpg");
        }


        private void setting_Load(object sender, EventArgs e)
        {
            //this.BackgroundImage = Image.FromFile(@"C:\Users\17290\Desktop\project_window\background.png");
            this.Text = "商店秒杀设置";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://login.taobao.com/member/login.jhtml?spm=a21bo.2017.754894437.1.5af911d9WLa7xz&f=top&redirectURL=https%3A%2F%2Fwww.taobao.com%2F";
            pr.chromem.Navigate().GoToUrl(url);
            pr.login(pr.chromem);
            pr.buy(pr.chromem,pr.choice,pr.buyTime,pr);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            //pr.chromem.Navigate().GoToUrl(pr.url);
        }
        private void button3_Click(object sender, EventArgs e)
        {

            //pr.chromem.Navigate().GoToUrl(pr.url);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pr.initUserName(textBox1.Text);
            //pr.initUrl(textBox1.Text);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            pr.initPassword(textBox2.Text);
            //pr.initUrl(textBox2.Text);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            pr.initUrl(textBox3.Text);
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            pr.initBuyTime(textBox4.Text);
            //pr.initUrl(textBox4.Text);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
