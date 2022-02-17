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



namespace Gamers_Hub_Butler__Code.Buttlers_Commands
{
    public class ButlersMoves : ModuleBase<SocketCommandContext>
    {
        [Command("tournament")]
        public async Task Tournament()
        {
            await ReplyAsync("Good day the tournament will be starting soon");
        }
        [Command("help")]
        public async Task help()
        {
            await ReplyAsync("my commands are tournament and rankings");
        }


        [Command("status")]
        public async Task status()
        {
            await Context.Client.SetGameAsync("call by !/bot");
            await Task.CompletedTask;
        }

        [Command("wallpaper")]

        public async Task wallpaper()
        {
            await Context.Channel.SendFileAsync(@"C:\Users\obi\Downloads\cum.jpg"  , "here you go");



        }

        [Command("ping")]       
        public async Task ping()
        {
            await ReplyAsync("pong\n " +
                "hello master type butler help for more information");
        }
        
                                                                                  
    }

}
