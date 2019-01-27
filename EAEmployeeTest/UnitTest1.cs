using System;
using EAAutoFramework.Base;
using EAEmployeeTest.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EAEmployeeTest
{
    [TestClass]
    public class UnitTest1
    {
        String url = "http://eaapp.somee.com/";

       
        [TestMethod]
        public void TestMethod1()
        {
            DriverContext.Driver = new ChromeDriver();
            DriverContext.Driver.Navigate().GoToUrl(url);

            LoginPage page = new LoginPage();
            page.ClickLoginLogin();
            page.Login("admin", "password");

            EmployeePage employeePage = page.ClickEmployeeList();
            employeePage.ClickCreateNew();
        }
    }
}
