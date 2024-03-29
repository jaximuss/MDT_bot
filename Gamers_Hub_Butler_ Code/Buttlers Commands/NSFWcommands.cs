﻿using System;
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
using Gamers_Hub_Butler__Code.Modules;
using Mdtbot.Data;

namespace Gamers_Hub_Butler__Code.Buttlers_Commands
{
    public class NSFWcommands : MdtBotModuelBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// intializes a new instance of <see cref="Commands"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The <see cref="IHttpClientFactory"/>to be used.</param>
        public NSFWcommands(IHttpClientFactory httpClientFactory, DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Command("nsfw")]
        [Alias("hentai", "show me")]
        [RequireNsfw()]
        public async Task NSFW(string subreddit = null)
        {
            HttpClient reddit = new HttpClient();
            var result = await reddit.GetStringAsync($"https://reddit.com/r/{subreddit ?? "hentai"}/random.json?limit-1");

            await Context.Channel.TriggerTypingAsync();
            await Task.Delay(2000);

            if (!result.StartsWith("["))
            {
                var message = await Context.Channel.SendMessageAsync("this does not exist man \n 🤨 what you trying to pull");

                await Task.Delay(3500);
                await message.DeleteAsync();

            }
            //turning result into a js so js can make it work idk
            JArray arr = JArray.Parse(result);
            JObject post = JObject.Parse(arr[0]["data"]["children"][0]["data"].ToString());

            EmbedBuilder embed = new EmbedBuilder()
                .WithImageUrl(post["url"].ToString())
                .WithTitle(post["title"].ToString())
                .WithColor(36, 190, 200);

            var ended = embed.Build();

            await Context.Channel.SendMessageAsync(null, false, ended);

        }
    }
}
