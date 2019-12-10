using System;
using AdventureWorks.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AdventureWorks.Web.Areas.Identity.IdentityHostingStartup))]
namespace AdventureWorks.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AdventureWorksWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AdventureWorksWebContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AdventureWorksWebContext>();
            });
        }
    }
}