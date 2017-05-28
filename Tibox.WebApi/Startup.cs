using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;

namespace Tibox.WebApi
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            //Hay k configurar el CORS tambien
            app.UseCors(CorsOptions.AllowAll);

            Register(config);

            //Llamamos al OAuth que se configuro
            ConfigureOAuth(app);

            ConfigureInjector(config);

            app.UseWebApi(config);
        }


    }
}