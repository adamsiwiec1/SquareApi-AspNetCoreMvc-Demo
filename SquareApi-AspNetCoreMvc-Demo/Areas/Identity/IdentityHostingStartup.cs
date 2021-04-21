using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SquareApi_AspNetCoreMvc_Demo.Data;

[assembly: HostingStartup(typeof(SquareApi_AspNetCoreMvc_Demo.Areas.Identity.IdentityHostingStartup))]
namespace SquareApi_AspNetCoreMvc_Demo.Areas.Identity
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