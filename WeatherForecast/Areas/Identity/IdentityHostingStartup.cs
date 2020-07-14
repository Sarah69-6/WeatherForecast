using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Data;

[assembly: HostingStartup(typeof(WeatherForecast.Areas.Identity.IdentityHostingStartup))]
namespace WeatherForecast.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WeatherForecastContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WeatherForecastContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<WeatherForecastContext>();
            });
        }
    }
}