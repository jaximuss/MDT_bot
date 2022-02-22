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
using Gamers_Hub_Butler__Code.leagueofapis;
using Gamers_Hub_Butler__Code.yugiohapis;
using Gamers_Hub_Butler__Code.Modules;
using Mdtbot.Data;

namespace Gamers_Hub_Butler__Code.Buttlers_Commands
{
    public class Yu_Gi_Oh_Commands : MdtBotModuelBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// intializes a new instance of <see cref="Yu_Gi_Oh_Commands"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The <see cref="IHttpClientFactory"/>to be used.</param>
        public Yu_Gi_Oh_Commands(IHttpClientFactory httpClientFactory, DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)

        {
            _httpClientFactory = httpClientFactory;
        }

        [Command("tournament")]
        public async Task Tournament()
        {
            await ReplyAsync("Good day the tournament will be starting soon...");
        }


        [Command("card info")]

        public async Task called(string named = null)
        {
            HttpClient yugioh = new HttpClient();
            var response = await yugioh.GetStringAsync($"https://db.ygoprodeck.com/api/v7/cardinfo.php?name={named ?? "Dark Magician"}");

            var card = Yugioh.FromJson(response);

            if (card == null)
            {
                await ReplyAsync("an error occured");
                return;
            }
            var race = card.Data[0].Race;
            var name = card.Data[0].Name;
            var id = card.Data[0].Id;
            var type = card.Data[0].Type;
            var Archetype = card.Data[0].Archetype;
            var Desc = card.Data[0].Desc;
            var Atk = card.Data[0].Atk;
            var Def = card.Data[0].Def;
            var Level = card.Data[0].Level;
            var Attribute = card.Data[0].Attribute;

            if (type == "Spell Card" || type == "Trap Card")
            {
                EmbedBuilder embed = new EmbedBuilder()
               .WithDescription("BIO")
               /*.WithImageUrl($"https://storage.googleapis.com/ygoprodeck.com/pics_small/{id}.jpg")*/
               .AddField("Name ", name, true)
               .AddField("ID : ", id, true)
               .AddField("Type : ", type, true)
               .AddField("Desc: ", Desc, true)
               .WithColor(36, 190, 200);
                var ended = embed.Build();

                await Context.Channel.SendMessageAsync(null, false, ended);
            }
            else if (Archetype == null)
            {

                EmbedBuilder embed = new EmbedBuilder()
                   .WithDescription("BIO")
                   .AddField("Name ", name, true)
                   .AddField("ID : ", id, true)
                   .AddField("Type : ", type, true)
                   .AddField("Desc: ", Desc, true)
                   .AddField("Atk : ", Atk, true)
                   .AddField("Def : ", Def, true)
                   .AddField("Level : ", Level, true)
                   .AddField("Attribute : ", Attribute, true)
                   .AddField("Race : ", race, true)


                   .WithColor(36, 190, 200);

                var ended = embed.Build();

                await Context.Channel.SendMessageAsync(null, false, ended);
            }
            else
            {

                EmbedBuilder embed = new EmbedBuilder()
                   .WithDescription("BIO")
                   .AddField("Name ", name, true)
                   .AddField("ID : ", id, true)
                   .AddField("Type : ", type, true)
                   .AddField("Desc: ", Desc, true)
                   .AddField("Archetype: ", Archetype, true)
                   .AddField("Atk : ", Atk, true)
                   .AddField("Def : ", Def, true)
                   .AddField("Level : ", Level, true)
                   .AddField("Attribute : ", Attribute, true)
                   .AddField("Race : ", race, true)
                   .WithColor(36, 190, 200);

                var ended = embed.Build();

                await Context.Channel.SendMessageAsync(null, false, ended);
            }
        }
    }
}
