using EAAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace EAEmployeeTest.Pages
{
    class LoginPage : BasePage
    {

     
        [FindsBy(How = How.LinkText, Using = "Log In")]
        public IWebElement lnkLogin { get;set;}

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        public IWebElement lnkEmployeeList { get; set; }

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement txtUserName
        {
            get; set;
        }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement txtPassword
        {
            get; set;
        }

        [FindsBy(How = How.CssSelector , Using = "input.btn")]
        public IWebElement btnLogin
        {
            get; set;
        }

        public void Login( string userName, string password)
        {
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
            btnLogin.Submit();
        }

        public void ClickLoginLogin()
        {
            btnLogin.Click();
        }

        public EmployeePage ClickEmployeeList()
        {
            //System.Threading.Thread.Sleep(5000);
            lnkEmployeeList.Click();
            
            return new EmployeePage();
        }
    }
}
