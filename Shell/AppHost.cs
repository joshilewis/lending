﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lending.Cqrs;
using Lending.Cqrs.Command;
using Lending.Domain;
using Lending.Domain.RequestConnection;
using Lending.Execution.DI;
using Lending.Execution.WebServices;
using Lending.Web;
using ServiceStack;
using ServiceStack.Authentication.OAuth2;
using ServiceStack.Authentication.OpenId;
using ServiceStack.Configuration;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.WebHost.Endpoints;

namespace Shell
{
    internal class AppHost : AppHostHttpListenerBase
    {
        private readonly IContainerAdapter containerAdapter;

        public AppHost(IContainerAdapter containerAdapter)
            : base("HttpListener Self-Host", typeof (Command).Assembly, typeof (Webservice<,>).Assembly)
        {
            this.containerAdapter = containerAdapter;
        }

        public override void Configure(Funq.Container container)
        {
            container.Adapter = containerAdapter;

            var appSettings = new AppSettings(); 

            Plugins.Add(new AuthFeature(
    () => new AuthUserSession(), //Use your own typed Custom UserSession type
    new IAuthProvider[] {
                    new GoogleOpenIdOAuthProvider(appSettings), //Sign-in with Google OpenId
                    new YahooOpenIdOAuthProvider(appSettings), //Sign-in with Yahoo OpenId
                    new OpenIdOAuthProvider(appSettings), //Sign-in with Custom OpenId
                    new GoogleOAuth2Provider(appSettings), //Sign-in with Google OAuth2 Provider
                    new LinkedInOAuth2Provider(appSettings), //Sign-in with LinkedIn OAuth2 Provider
                }));

            Routes
                .Add<RequestConnection>("/connection/add/{FromUserId}/{ToUserId}/")
                ;
        }
    }

}
