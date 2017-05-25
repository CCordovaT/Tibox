using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tibox.Automation;
using Xunit;

namespace Tibox.AutomationTests
{
    public class LoginPageTestNavigation
    {

        public LoginPageTestNavigation()
        {
            Driver.GetInstance(DriverOption.Chrome);
        }

        [Fact]
        public void LoginTest()
        {
            LoginPage.Go();
            LoginPage.LoginAs("christian@hotmail.com").WithPassword("1234").Login();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            LoginPage.GetUrl().Should().Be("http://localhost:81/Tibox.Web/#!/product");
            LoginPage.LogOut();
            Driver.CloseInstance();
        }

        [Fact]
        public void LoginFailedTest()
        {
            LoginPage.Go();
            LoginPage.LoginAs("christian@hotmail.com").WithPassword("12345").Login();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            LoginPage.IsAlertErrorPresent().Should().BeTrue();
            LoginPage.LogOut();
            Driver.CloseInstance();
        }
    }
}
