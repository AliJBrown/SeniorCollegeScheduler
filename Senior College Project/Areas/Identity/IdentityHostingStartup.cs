using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Senior_College_Project.Areas.Identity.Data;
using Senior_College_Project.Data;

[assembly: HostingStartup(typeof(Senior_College_Project.Areas.Identity.IdentityHostingStartup))]
namespace Senior_College_Project.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Senior_College_ProjectContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Senior_College_ProjectContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>()
                    .AddEntityFrameworkStores<Senior_College_ProjectContext>();
            });
        }
    }
}