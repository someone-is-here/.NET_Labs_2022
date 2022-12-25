using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WEB_053501_Tatsiana_Shurko.Data;
using WEB_053501_Tatsiana_Shurko.Entities;

[assembly: HostingStartup(typeof(WEB_053501_Tatsiana_Shurko.Areas.Identity.IdentityHostingStartup))]
namespace WEB_053501_Tatsiana_Shurko.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
