using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tibox.Automation;
using Tibox.Models;
using Xunit;

namespace Tibox.AutomationTests
{
    public class SupplierCRUDTest
    {

        public SupplierCRUDTest()
        {
            Driver.GetInstance(DriverOption.Chrome);
        }

        [Fact]
        public void ConsultAll()
        {
            LoginPage.Go();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            LoginPage.LoginAs("christian@hotmail.com").WithPassword("1234").Login();
            Thread.Sleep(TimeSpan.FromSeconds(3));

            SupplierPage.Go();
            SupplierPage.GetUrl().Should().Be("http://localhost:81/Tibox.Web/#!/supplier");

            Thread.Sleep(TimeSpan.FromSeconds(2));

            LoginPage.LogOut();
            Driver.CloseInstance();
        }

        [Fact]
        public void InsertSupplier()
        {
            LoginPage.Go();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            LoginPage.LoginAs("christian@hotmail.com").WithPassword("1234").Login();
            Thread.Sleep(TimeSpan.FromSeconds(3));

            var _supplier = new Supplier
            {
                City = "cityTest",
                CompanyName = "companyTest",
                ContactName = "contactTest",
                ContactTitle = "titleTest",
                Country = "countryTest",
                Fax = "faxTest",
                Phone = "phoneTest"
            };

            SupplierPage.Go();
            SupplierPage.StartCreate().WithEntity(_supplier).Create();

            Thread.Sleep(TimeSpan.FromSeconds(2));

            SupplierPage.IsMessageConfirmVisible().Should().BeTrue();

            LoginPage.LogOut();
            Driver.CloseInstance();
        }

        [Fact]
        public void InsertSupplierWithErrorModelState()
        {
            LoginPage.Go();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            LoginPage.LoginAs("christian@hotmail.com").WithPassword("1234").Login();
            Thread.Sleep(TimeSpan.FromSeconds(3));

            var _supplier = new Supplier
            {
                City = "cityTest",
                CompanyName = "",
                ContactName = "contactTest",
                ContactTitle = "titleTest",
                Country = "countryTest",
                Fax = "faxTest",
                Phone = "phoneTest"
            };

            SupplierPage.Go();
            SupplierPage.StartCreate().WithEntity(_supplier).Create();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            SupplierPage.IsMessageErrorVisible().Should().BeTrue();
            SupplierPage.CloseModal();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            LoginPage.LogOut();
            Driver.CloseInstance();
        }

        [Fact]
        public void UpdateSupplier()
        {
            LoginPage.Go();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            LoginPage.LoginAs("christian@hotmail.com").WithPassword("1234").Login();
            Thread.Sleep(TimeSpan.FromSeconds(3));

            SupplierPage.Go();
            SupplierPage.StartUpdate().Edit();

            Thread.Sleep(TimeSpan.FromSeconds(2));

            SupplierPage.IsMessageConfirmVisible().Should().BeTrue();

            LoginPage.LogOut();
            Driver.CloseInstance();
        }

        [Fact]
        public void UpdateSupplierWithModelStateError()
        {
            LoginPage.Go();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            LoginPage.LoginAs("christian@hotmail.com").WithPassword("1234").Login();
            Thread.Sleep(TimeSpan.FromSeconds(3));

            SupplierPage.Go();
            SupplierPage.StartUpdate().EditWithError();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            SupplierPage.IsMessageErrorVisible().Should().BeTrue();
            SupplierPage.CloseModal();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            LoginPage.LogOut();
            Driver.CloseInstance();
        }

        [Fact]
        public void DeleteSupplier()
        {
            LoginPage.Go();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            LoginPage.LoginAs("christian@hotmail.com").WithPassword("1234").Login();
            Thread.Sleep(TimeSpan.FromSeconds(3));

            SupplierPage.Go();
            SupplierPage.StartDelete().Delete();

            Thread.Sleep(TimeSpan.FromSeconds(2));

            SupplierPage.IsMessageConfirmVisible().Should().BeTrue();

            LoginPage.LogOut();
            Driver.CloseInstance();
        }

    }
}
