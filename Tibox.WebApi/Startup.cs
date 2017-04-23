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
            Register(config);

            //Llamamos al OAuth que se configuro
            ConfigureOAuth(app);

            //Hay k configurar el CORS tambien
            app.UseCors(CorsOptions.AllowAll);
            ConfigureInjector(config);

            app.UseWebApi(config);
        }


    }
}