﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cab_management_System.Startup))]
namespace Cab_management_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
