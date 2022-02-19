using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Discord;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.Webhook;
using Discord.WebSocket;
using System.Net.Http;
using Newtonsoft.Json.Linq;


namespace Gamers_Hub_Butler__Code.Buttlers_Commands
{
    public class Yu_Gi_Oh_Commands : ModuleBase<SocketCommandContext>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        /// <summary>
        /// intializes a new instance of <see cref="Yu_Gi_Oh_Commands"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The <see cref="IHttpClientFactory"/>to be used.</param>
        public Yu_Gi_Oh_Commands(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ;
        }

        [Command("tournament")]
        public async Task Tournament()
        {
            await ReplyAsync("Good day the tournament will be starting soon...");
        }

        [Command("cards")]

        public async Task Name()
        {
           
         

           
        }
    }

}
