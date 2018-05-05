using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace ConsoleApp4
{

    class Program
    {
        private static IWebDriver driver;
        private bool acceptNextAlert = true;
        private static int repeatLoop = 10;
        private static long timeSleep = 0;
        static void Main(string[] args)
        {
           // DodawanieKomenatrza();
             WyswietlenieWszstkichProduktowWPaneluAdmina();
             //ZakupProduktu();
        }

        public static IWebElement FindElementIfExists(By by)
        {
            IWebElement element = null;
            try
            {
                element = driver.FindElement(@by);
            }
            catch (NoSuchElementException)
            {

            }

            return element;
        }

        public static void DodawanieKomenatrza()
        {
            driver = new ChromeDriver();
            bool flag = true;

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < repeatLoop; i++)
            {

                driver.Navigate().GoToUrl("http://projektzai-001-site1.dtempurl.com/");
                driver.FindElement(By.XPath("(//img[@alt='Produkt'])[4]")).Click();

                if (driver.Title != "Laptop5")
                {
                    flag = false;
                }

                driver.FindElement(By.Id("pills-contact-tab")).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("commentContent")));
                driver.FindElement(By.Id("commentContent")).Click();
                driver.FindElement(By.Id("commentContent")).Clear();
                driver.FindElement(By.Id("commentContent")).SendKeys("test selenium");
                driver.FindElement(By.Id("sendComment")).Click();
                element = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("contentModal")));
                driver.FindElement(By.XPath("//div[@id='myModal']/div/div/div[3]/button/span")).Click();
            }
            sw.Stop();
            Console.WriteLine("Udany test? " + flag);
            Console.WriteLine("Time in {0} ms", sw.ElapsedMilliseconds);
        }

        public static void WyswietlenieWszstkichProduktowWPaneluAdmina()
        {
            driver = new ChromeDriver();
            bool flag = true;

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < repeatLoop; i++)
            {
                driver.Navigate().GoToUrl("http://projektzai-001-site1.dtempurl.com/Admin");
                driver.FindElement(By.XPath("//li[4]/a/span")).Click();
                if (driver.Title != "Produkty")
                {
                    flag = false;
                }
            }
            sw.Stop();
            Console.WriteLine("Udany test? " + flag);
            Console.WriteLine("Time in {0} ms", sw.ElapsedMilliseconds);
        }

        public static void ZakupProduktu()
        {
            driver = new ChromeDriver();
            bool flag = true;

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < repeatLoop; i++)
            {
                driver.Navigate().GoToUrl("http://projektzai-001-site1.dtempurl.com/");
                driver.FindElement(By.LinkText("Zaloguj się")).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("signINLogin")));

                driver.FindElement(By.Id("signINLogin")).Click();
                driver.FindElement(By.Id("signINLogin")).Clear();
                driver.FindElement(By.Id("signINLogin")).SendKeys("Dawid");
                driver.FindElement(By.Id("signINPassword")).Clear();
                driver.FindElement(By.Id("signINPassword")).SendKeys("Dawid1234");
                driver.FindElement(By.XPath("//button[@id='signINButton']/span")).Click();
                element = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Button_add_to_cart")));
                driver.FindElement(By.XPath("(//input[@id='Button_add_to_cart'])[7]")).Click();
                driver.FindElement(By.XPath("//div[2]/a/span")).Click();
                driver.FindElement(By.XPath("//div/button/span")).Click();
                driver.FindElement(By.LinkText("Wyloguj się")).Click();

                if (driver.Title != "Sklep")
                {
                    flag = false;
                }
            }
            sw.Stop();
            Console.WriteLine("Udany test? " + flag);
            Console.WriteLine("Time in {0} ms", sw.ElapsedMilliseconds);
        }

    }

}
