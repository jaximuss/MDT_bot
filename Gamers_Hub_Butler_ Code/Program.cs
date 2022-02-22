using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using Discord;
using Discord.Addons.Hosting;
using System.Reflection;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Mdtbot.Data.Context;
using Microsoft.Extensions.Hosting;
using Gamers_Hub_Butler__Code.services;
using Mdtbot.Data;

namespace Gamers_Hub_Butler__Code
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration(x =>
                {
                    var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false, true).Build();


                    x.AddConfiguration(configuration);
                })

                .ConfigureLogging(x =>
                {
                    x.AddConsole();
                    x.SetMinimumLevel(LogLevel.Debug);
                })
                .ConfigureDiscordHost((context, config) =>
                {
                    config.SocketConfig = new DiscordSocketConfig
                    {
                        LogLevel = LogSeverity.Debug,
                        AlwaysDownloadUsers = true,
                        MessageCacheSize = 200,
                    };

                    config.Token = context.Configuration["Token"];
                })
                .UseCommandService((context, config) =>
                {
                    config.CaseSensitiveCommands = false;
                    config.LogLevel = LogSeverity.Debug;
                    config.DefaultRunMode = RunMode.Sync;

                })
                .ConfigureServices((context, services) =>
                {
                    services
                    .AddHostedService<CommandHandler>()
                    .AddHttpClient()
                    .AddDbContextFactory<MdtbotDBContext>(options => 
                    options.UseMySql(
                        context.Configuration.GetConnectionString("Default"),
                        new MySqlServerVersion(new Version(8, 0, 28))))
                    .AddSingleton<DataAccessLayer>();

                })
                .UseConsoleLifetime();

            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
      
   


     

    

