using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibox.Automation
{
    public class SimpleTest
    {
        public void Navigate()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.google.com.pe");
            driver.Close();
            driver.Quit();
            driver = null;
        }
    }
}
