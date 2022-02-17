using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using Discord;
using System.Reflection;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;




namespace Gamers_Hub_Butler__Code
{
    class Program
    {
        static void Main(string[] args) => new Program().GamersHubb().GetAwaiter().GetResult();
        
       


        
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;

        public async Task GamersHubb()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection().AddSingleton(_client).AddSingleton(_commands).BuildServiceProvider();

            string token = File.ReadAllText(@"C:\TOOKEN\token.txt") ;//api token

            _client.Log += _client_Log;

            await ButlersCommands();

            await _client.LoginAsync(TokenType.Bot, token);

            await _client.StartAsync();

           
                

            

            await Task.Delay(-1);//to stop the bot from closing

        }

        private Task _client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public async Task ButlersCommands()
        {
            _client.MessageReceived += HandleCommandAsync;

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }
        
        private async Task HandleCommandAsync(SocketMessage arg)    
        {
            var messageSent = arg as SocketUserMessage;
            var context = new SocketCommandContext(_client, messageSent);   

            if (messageSent.Author.IsBot) return;

            int argPos = 0;
            if ( messageSent.HasStringPrefix("!", ref argPos) || messageSent.HasStringPrefix("bot", ref argPos))//how to call the bot
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
            if (!result.IsSuccess) Console.WriteLine(result.ErrorReason); //bugfixing
            }
            
        }
       
            
     

    }
}
