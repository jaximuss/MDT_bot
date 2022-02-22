using Discord.Addons.Hosting;
using Discord.WebSocket;
using Mdtbot.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamers_Hub_Butler__Code.services
{
   public abstract  class MdtBotSevice : DiscordClientService
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public readonly DiscordSocketClient Client;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public readonly ILogger<DiscordClientService> Logger;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        public readonly IConfiguration Configuration;
        public readonly DataAccessLayer Dataaccesslayer;

        public MdtBotSevice(DiscordSocketClient client, ILogger<DiscordClientService> logger, IConfiguration configuration, DataAccessLayer dataaccesslayer)
            :base (client , logger)
        {
            Client = client;
            Logger = logger;
            Configuration = configuration;
            Dataaccesslayer = dataaccesslayer;
        }
    }
}
