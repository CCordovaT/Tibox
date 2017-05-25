using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tibox.Models;

namespace Tibox.Automation
{
    public class SupplierPage
    {
        public static void Go()
        {
            Driver.Instance.Navigate().GoToUrl("http://localhost:81/Tibox.Web/#!/supplier");
        }

        public static string GetUrl()
        {
            return Driver.Instance.Url;
        }

        public static SupplierCRUD StartCreate()
        {
            Driver.Instance.FindElement(By.CssSelector("button[ng-click='vm.create();']")).Click();
            return new SupplierCRUD();
        }

        public static SupplierCRUD StartUpdate()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElements(By.CssSelector("button[ng-click*='vm.edit();")));

            var a = Driver.Instance.FindElements(By.CssSelector("button[ng-click*='vm.edit();']"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.Instance;
            js.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)", "");

            a[a.Count() - 1].Click();

            return new SupplierCRUD();
        }

        public static SupplierCRUD StartDelete()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElements(By.CssSelector("button[ng-click*='vm.Delete();")));            
            
            var a = Driver.Instance.FindElements(By.CssSelector("button[ng-click*='vm.Delete();"));

            IJavaScriptExecutor js = (IJavaScriptExecutor) Driver.Instance;
            js.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)", "");

            a[a.Count() - 1].Click();

            return new SupplierCRUD();
        }

        public static bool IsMessageConfirmVisible()
        {
            IWebElement _message;

            try
            {
                _message = Driver.Instance.FindElement(By.CssSelector("div[ng-if='vm.showMessageConfirm']"));
            }
            catch (Exception)
            {
                return false;
            }
            
            return _message.Displayed;
        }

        public static bool IsMessageErrorVisible()
        {
            IWebElement _message;

            try
            {
                _message = Driver.Instance.FindElement(By.CssSelector("ul[ng-if='showErrors']"));
            }
            catch (Exception)
            {
                return false;
            }

            return _message.Displayed;
        }

        public static SupplierCRUD CloseModal()
        {
            Driver.Instance.FindElement(By.CssSelector("button[ng-click='closeFunction();']")).Click();
            return new SupplierCRUD();
        }

    }

    public class SupplierCRUD
    {
        private Supplier m_supplier;

        public SupplierCRUD WithEntity(Supplier _supplier)
        {
            m_supplier = _supplier;
            return this;
        }

        public void Create()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));

            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.CssSelector("input[ng-model='supplier.companyName']")));

            Driver.Instance.FindElement(By.CssSelector("input[ng-model='supplier.companyName']")).SendKeys(m_supplier.CompanyName);
            Driver.Instance.FindElement(By.CssSelector("input[ng-model='supplier.contactName']")).SendKeys(m_supplier.ContactName);
            Driver.Instance.FindElement(By.CssSelector("input[ng-model='supplier.contactTitle']")).SendKeys(m_supplier.ContactTitle);
            Driver.Instance.FindElement(By.CssSelector("input[ng-model='supplier.city']")).SendKeys(m_supplier.City);
            Driver.Instance.FindElement(By.CssSelector("input[ng-model='supplier.country']")).SendKeys(m_supplier.Country);
            Driver.Instance.FindElement(By.CssSelector("input[ng-model='supplier.phone']")).SendKeys(m_supplier.Phone);
            Driver.Instance.FindElement(By.CssSelector("input[ng-model='supplier.fax']")).SendKeys(m_supplier.Fax);

            Driver.Instance.FindElement(By.CssSelector("button[ng-click='saveFunction();']")).Click();
        }

        public void Edit()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));

            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.CssSelector("input[ng-model='supplier.companyName']")));

            Driver.Instance.FindElement(By.CssSelector("input[ng-model='supplier.companyName']")).SendKeys("nombre cambiado");
                        
            Driver.Instance.FindElement(By.CssSelector("button[ng-click='saveFunction();']")).Click();
        }

        public void EditWithError()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));

            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.CssSelector("input[ng-model='supplier.companyName']")));

            Driver.Instance.FindElement(By.CssSelector("input[ng-model='supplier.companyName']")).Clear();

            Driver.Instance.FindElement(By.CssSelector("button[ng-click='saveFunction();']")).Click();
        }

        public void Delete()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));

            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.CssSelector("input[ng-model='supplier.companyName']")));

            Driver.Instance.FindElement(By.CssSelector("button[ng-click='saveFunction();']")).Click();
        }
    }
}

