﻿using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(CarRentalWebApp.Startup))]
namespace CarRentalWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}