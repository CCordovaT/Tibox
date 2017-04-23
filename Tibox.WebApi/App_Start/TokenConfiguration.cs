using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using Tibox.WebApi.Provider;

namespace Tibox.WebApi
{
    public partial class Startup
    {

        public void ConfigureOAuth(IAppBuilder app)
        {

            var OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {

                AllowInsecureHttp = true, //Si permite lugares seguros
                TokenEndpointPath = new PathString("/token"), //La ruta donde se solicitara el token
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1), //El tiempo de vida, normalmente el tiempo de trabajo del usuario
                Provider = new SimpleAuthorizationServerProvider() //Proveedor, permite indicar cual queremos usar, podemos crear uno personalizado

            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions); //Usa la configuracion que le hemos puesto
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions()); //Indicamos que usaremos el Bearer, la otra forma a lo habitual del OAuth

        }

    }
}