using FluentValidation;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Tibox.Models;
using Tibox.WebApi.Validators;

namespace Tibox.WebApi
{
    public partial class Startup
    {

        public void ConfigureInjector(HttpConfiguration config)
        {

            var container = new ServiceContainer();
            container.RegisterAssembly(Assembly.GetExecutingAssembly());
            container.RegisterAssembly("Tibox.Repository*.dll");
            container.RegisterAssembly("Tibox.UnitOfWork*.dll");

            container.Register<AbstractValidator<Product>, ProductValidator>();


            container.RegisterApiControllers();
            container.EnableWebApi(config);

        }

    }
}