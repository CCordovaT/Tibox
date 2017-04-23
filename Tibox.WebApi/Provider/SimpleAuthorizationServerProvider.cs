using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tibox.UnitOfWork;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Tibox.WebApi.Provider
{
    public class SimpleAuthorizationServerProvider: OAuthAuthorizationServerProvider
    {

        private readonly IUnitOfWork _unit;

        public SimpleAuthorizationServerProvider()
        {
            _unit = new TiboxUnitOfWork();
        }

        //Al heredar podemos sobreescribir metodos

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //Siempre valida el contexto
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //Aqui validaremos el usuario y contraseña
            var user = _unit.Users.ValidateUser(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "Usuario o password incorrecto");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", user.Roles));

            context.Validated(identity);

        }

    }
}