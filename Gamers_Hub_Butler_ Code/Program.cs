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
using Microsoft.Extensions.Configuration;

namespace Gamers_Hub_Butler__Code
{
    class Program
    {
        static void Main(string[] args) => new Program().GamersHubb().GetAwaiter().GetResult();
      
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;
        public IConfiguration _configuration;
        public async Task GamersHubb()
        {
            
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection().AddSingleton(_client).AddSingleton(_commands).AddHttpClient().BuildServiceProvider();

            string token = File.ReadAllText(@"C:\TOOKEN\token.txt") ;//api token

            _client.Log += _client_Log;

            await ButlersCommands();

            await _client.LoginAsync(TokenType.Bot, token);

            await _client.StartAsync();

            await Task.Delay(-1);//to stop the bot from closing

        }
        public class ConfigurationHandler : Program
        {
           

            public ConfigurationHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

        }

        private Task _client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public async Task ButlersCommands()        /*this is the event handler*/
        {
            _client.MessageReceived += HandleCommandAsync;
            //_client.ReactionAdded += ReactionAdded; // for roles

           //for bulk messages being deleted _client.MessagesBulkDeleted;
            
            _client.ChannelCreated += OnChannelCreated;

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

       /*private Task ReactionAdded(Cacheable<IUserMessage, ulong> arg1, ISocketMessageChannel arg2, SocketReaction arg3)
        {
            _ = Task.Run(async () =>
            {
                if (arg3.MessageId != 944272839652032562) return;
                if (arg3.Emote.Name != "🔥") return;

                var role = (arg2 as SocketGuildChannel).Guild.Roles.FirstOrDefault(x => x.Id == 709887414625239081);

                await (arg3.User.Value as SocketGuildUser).AddRoleAsync(role);
            });
            return Task.CompletedTask;
        }*///adding roles

        private Task OnChannelCreated(SocketChannel arg)
        {
            _ = Task.Run(async () => 
            {
                //if the channel being created is not a text channel do nothing else
                if ((arg as ITextChannel) == null) return;
            //do this
            var channel = arg as ITextChannel;

            await channel.SendMessageAsync("the event was called");
            }
            );
            return Task.CompletedTask;
        }

        private Task HandleCommandAsync(SocketMessage arg)
        {
            _ = Task.Run(async () => 
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
           });
            return Task.CompletedTask;
        }
       


     

    }
}
