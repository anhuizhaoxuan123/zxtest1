using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Security.Permissions;


namespace project_window
{
    class Program
    {
        public IWebDriver chromem;
        public string url;
        //"https://login.taobao.com/member/login.jhtml?spm=a21bo.2017.754894437.1.5af911d9WLa7xz&f=top&redirectURL=https%3A%2F%2Fwww.taobao.com%2F";
        //"https://chaoshi.detail.tmall.com/item.htm?spm=a1z0d.6639537.1997196601.169.106c7484bsf0w1&id=20739895092";
        public string buyTime;
        public string username;
        public string password;
        public string choice;
        public void initUrl(string urli)
        {
            url = urli;
        }
        public void initBuyTime(string buyTimei)
        {
            buyTime = buyTimei;
        }
        public void initUserName(string userNamei)
        {
            username = userNamei;
        }
        public void initPassword(string passwordi)
        {
            password = passwordi;
        }
        public  void login(IWebDriver chromei)
        {
            //chromei.Navigate().GoToUrl(url);
            chromei.FindElement(By.Id("fm-login-id")).Click();
            chromei.FindElement(By.Id("fm-login-id")).SendKeys(username);
            chromei.FindElement(By.Id("fm-login-password")).Click();
            chromei.FindElement(By.Id("fm-login-password")).SendKeys(password);
            Thread.Sleep(5000);
            chromei.FindElement(By.XPath("//button")).Click();
            Thread.Sleep(10000);
        }


        public void initChrome()
        {
            ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;//关闭黑色cmd窗口

            ChromeOptions options = new ChromeOptions();
            // 不显示浏览器
            //options.AddArgument("--headless");
            // GPU加速可能会导致Chrome出现黑屏及CPU占用率过高,所以禁用
            options.AddArgument("--disable-gpu");
            // 伪装user-agent
            options.AddArgument("user-agent=Mozilla/5.0 (iPhone; CPU iPhone OS 10_3 like Mac OS X) AppleWebKit/602.1.50 (KHTML, like Gecko) CriOS/56.0.2924.75 Mobile/14E5239e Safari/602.1");
            // 设置chrome启动时size大小
            options.AddArgument("--window-size=1400,600");

            chromem = new ChromeDriver(driverService, options);
        }

        public void buy(IWebDriver chromeb, string choiceb, string buyTimeb,Program pr)
        {
            bool flag = true;
            while (flag)//
            {

                DateTime buyTime = Convert.ToDateTime(buyTimeb);
                while (flag)
                {
                    DateTime nowTime = Convert.ToDateTime(DateTime.Now.ToString());
                    if (buyTime < nowTime)
                    {
                        break;
                    }
                }
                while (flag)
                {
                    chromeb.Navigate().GoToUrl(url);

                    if (choiceb == "立即购买")
                    {
                        Thread.Sleep(5000);
                        //chromeb.FindElement(By.Id("fm-login-id")).Click();
                        //chromeb.FindElement(By.Id("fm-login-id")).SendKeys(pr.username);
                        //chromeb.FindElement(By.Id("fm-login-password")).Click();
                        //chromeb.FindElement(By.Id("fm-login-password")).SendKeys(pr.password);
                        chromeb.FindElement(By.Id("立即购买")).Click();
                        flag = false;
                    }
                    if (choiceb == "加入购物车")

                    {
                        Thread.Sleep(5000);
                        //login(chromem);
                        chromeb.FindElement(By.XPath("//p[text()='加入购物车']")).Click();
                        Thread.Sleep(5000);
                        chromeb.FindElement(By.XPath("//span[text()='FT8763/主图款']")).Click();
                        Thread.Sleep(5000);
                        chromeb.FindElement(By.XPath("//p[text()='确定']")).Click();
                        Thread.Sleep(5000);
                        login(chromem);
                        chromem.FindElement(By.XPath("//p[text()='确定']")).Click();

                        flag = false;
                    }
                }

            }
        }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new setting());
            //this.BackgroundImage = Image.FromFile(@"C:\Users\17290\Desktop\project_window\background.jpg");



        }
    }
}
