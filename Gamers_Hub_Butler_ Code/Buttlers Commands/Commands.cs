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
using Gamers_Hub_Butler__Code.Modules;
using Mdtbot.Data;

namespace Gamers_Hub_Butler__Code.Buttlers_Commands
{
    public class Commands : MdtBotModuelBase
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public readonly SocketReaction _emote;

        /// <summary>
        /// intializes a new instance of <see cref="Commands"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The <see cref="IHttpClientFactory"/>to be used.</param>
        public Commands(IHttpClientFactory httpClientFactory, DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
            _httpClientFactory = httpClientFactory;
        }

        //[Command("prefix")]
        //public async Task PrefixAsync(string prefix = null)
        //{
        //    if (prefix == null)
        //    {
        //        var CurrenPrefix = DataAccessLayer.GetPrefix(Context.Guild.Id);
        //        await ReplyAsync($"the prefix of this server is {CurrenPrefix}");
        //        return;
        //    }

        //    await DataAccessLayer.SetPrefix(Context.Guild.Id, prefix);
        //    await ReplyAsync($"The prefix has been set too {prefix}");
        //}

       
        [Command ("register")]
        public async Task leagued()
        {
            var members = new  LeagueMembers();
            var playersID = members.Members;
            var usernames = members.names;
            await ReplyAsync("MASTER DUEL LEAGUE");

            for (int i = 0; i < playersID.Length; i++)
            {

                var CurrentMember = DataAccessLayer.JoinTournament(playersID[i], usernames[i]);
                
            }
        }


        [Command("Table")]
        [Alias ("league")]
        [RequireUserPermission(ChannelPermission.ManageMessages)]
        public async Task asdw()
        {
            var points = 0;
            var members = new LeagueMembers();
            var playersID = members.Members;
            var usernames = members.names;
            await ReplyAsync("MASTER DUEL LEAGUE");
            var embed = new EmbedBuilder()
                .WithDescription("MASTER DUEL LEAGUE (updated!)")
                .AddField($"1. {usernames[19]} ", points +18+ " points", false)
                .AddField($"2.  {usernames[4]} ", points +16+ " points", false)
                .AddField($"3.{usernames[1]} ", points + 13 + " points", false )
                .AddField($"4.  {usernames[12]} ", points+ 3+  " points", false)
                .AddField($"5. {usernames[16]} ", points +2 + " points", false)
                .AddField($"6. {usernames[9]} ", points +1+ " points", false)
                .AddField($"7. {usernames[2]} ", points +   " points", false)
                .AddField($"8. {usernames[14]} ", points +  " points", false)
                .AddField($"9. {usernames[7]} ", points+  " points", false)
                .AddField($"10. {usernames[6]} ", points+  " points", false)
                .AddField($"11. {usernames[3]} ", points + " points", false)
                .AddField($"12. {usernames[11]} ", points + " points", false)
                .AddField($"13. {usernames[8]} ", points + " points", false)
                .AddField($"14. {usernames[13]} ", points+ " points", false)
                .AddField($"15. {usernames[0]} ", points + " points", false)
                .AddField($"16. {usernames[15]} ", points + " points", false)
                .AddField($"17. {usernames[10]} ", points +   " points", false)
                .AddField($"18. {usernames[17]} ", points + " points", false)
                .AddField($"18. {usernames[18]} ", points + " points", false)
                .AddField($"18. {usernames[5]} ", points + " points", false)

                .WithColor(Color.DarkBlue)
                .Build();

            await Context.Channel.SendMessageAsync(null, false, embed);

            //for (int i = 0; i < playersID.Length; i++)
            //{

            //    var CurrentMember = DataAccessLayer.GetUsername(playersID[i], usernames[i]);
            //    await ReplyAsync($"{i}. {CurrentMember}");
            //}



        }
       
        [Command("status")]
        public async Task status()
        {
            await Context.Client.SetGameAsync("call by !commands");

        }


        [Command("myresult")]
        public async Task details()
        {

            await Context.Channel.TriggerTypingAsync();
            await Task.Delay(2000);

            var builder = new EmbedBuilder()
                .WithThumbnailUrl(Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                .WithDescription($"Hello!!! {Context.User.Username} these are you past results.")
                .WithColor(44, 222, 207)
                .WithCurrentTimestamp();

            var build = builder.Build();

            await ReplyAsync(null, false, build);
        }


        //[Command("roles")]
        //[Alias("role")]
        //public async Task Role(SocketGuildUser user = null)
        //{
        //    if (user == null)
        //    {
        //        var role = building()
        //               .AddField("Your roles are :", string.Join(" \n", (Context.User as SocketGuildUser).Roles.Select(x => x.Mention)), true)
        //               .Build();
        //        await ReplyAsync(null, false, role);
        //    }
        //    else
        //    {
        //        var role = new EmbedBuilder()
        //            .WithThumbnailUrl(user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl())
        //        .WithColor(44, 222, 207)
        //        .WithCurrentTimestamp()
        //          .AddField("Your roles are :", string.Join(" \n", user.Roles.Select(x => x.Mention)), true)
        //          .Build();
        //        await ReplyAsync(null, false, role);
        //    }



        //}


        [Command("delete")]
        [RequireUserPermission(ChannelPermission.ManageMessages)]
        public async Task Delete(int amount)
        {
            //we have to add the amount to a variable
            //get the message from the current channecl(context)
            var messages = await Context.Channel.GetMessagesAsync(amount).FlattenAsync();

            await (Context.Channel as SocketTextChannel).DeleteMessagesAsync(messages);


            var message1 = await Context.Channel.SendMessageAsync($"there were {messages.Count()} messages deleted");

            await Task.Delay(2500);

            var message2 = await Context.Channel.SendMessageAsync("see you on the flip side");

            await Task.Delay(2500);

            await message1.DeleteAsync();
            await message2.DeleteAsync();
        }


        [Command("info")]
        public async Task Info(SocketGuildUser Users = null)
        {

            await Context.Channel.TriggerTypingAsync();
            await Task.Delay(2000);
            if (Users == null)
            {
                var embuild = new EmbedBuilder()
                    .WithThumbnailUrl(Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                    .WithDescription($"User name {Context.User.Username}")
                    .WithColor(36, 200, 200)
                    .AddField("USER ID ", Context.User.Id, true)
                    .AddField("Date Created ", Context.User.CreatedAt.ToString("dd/MM/yyyy"), true)
                    .AddField("joined the server", (Context.User as SocketGuildUser).JoinedAt.Value.ToString("dd/MM/yyyy"), true)
                    .AddField("tag", Context.User.Discriminator, true);

                var build = embuild.Build();
                await Context.Channel.SendMessageAsync(null, false, build);

            }
            else
            {
                var enbuild = new EmbedBuilder()
                      .WithThumbnailUrl(Users.GetAvatarUrl() ?? Users.GetDefaultAvatarUrl())
                    .WithDescription($"User name {Users.Username}")
                    .WithColor(36, 200, 200)
                    .AddField("USER ID ", Users.Id, true)
                    .AddField("Date Created ", Users.CreatedAt.ToString("dd/MM/yyyy"), true)
                    .AddField("joined the server", Users.JoinedAt.Value.ToString("dd/MM/yyyy"), true)
                    .AddField("tag", Users.Discriminator, true);

                var builds = enbuild.Build();
                await Context.Channel.SendMessageAsync(null, false, builds);

            }
        }


        [Command("commands")]
        public async Task Allcommands()
        {
            var embuild = new EmbedBuilder()
                  .WithDescription($"Hello {Context.User.Username}  \nmy commands are  : \n[info (@username)],\n [NSFW(FOR NSFW CHANNELS ONLY)] \n [card info], \n [roles], \n [tournament].")
                  .WithColor(36, 200, 200);



            var build = embuild.Build();
            await Context.Channel.SendMessageAsync(null, false, build);
        }

    }

}
