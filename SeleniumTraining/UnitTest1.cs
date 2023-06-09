using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTraining
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;

        [TestInitialize]
        public void OpenBrowser() 
        {
            Console.WriteLine("setup");
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path+"/driver/chromedriver.exe");
            driver.Navigate().GoToUrl("http://todo.ly/");
        }

        [TestCleanup]
        public void CloseBrowser() 
        {
            Console.WriteLine("clean");
            driver.Quit();
        }

        [TestMethod]
        public void VerifyTheLoginIsSuccessfuly()
        {
            // click login button
            driver.FindElement(By.XPath("//img[@src=\"/Images/design/pagelogin.png\"]")).Click();
            // fill email textbox
            driver.FindElement(By.Id("ctl00_MainContent_LoginControl1_TextBoxEmail")).SendKeys("bootcamp2@mojix.com");
            // fill password textbox
            driver.FindElement(By.Id("ctl00_MainContent_LoginControl1_TextBoxPassword")).SendKeys("12345");
            // click login button
            driver.FindElement(By.Id("ctl00_MainContent_LoginControl1_ButtonLogin")).Click();
            // verify -> the logout button should be displayed

            Assert.IsTrue(driver.FindElement(By.Id("ctl00_HeaderTopControl1_LinkButtonLogout")).Displayed, 
                "ERROR !! the login was not successfully, review credentials please");

        }
    }
}