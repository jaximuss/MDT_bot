                                                                                                                                                                                                                                                                            using System;

namespace Gamers_Hub_Butler__Code.services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Discord.Addons.Hosting;
    using Discord.Commands;
    using Mdtbot.Data;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Discord;
    using Discord.WebSocket;

    public class CommandHandler : MdtBotSevice
    {
        private readonly IServiceProvider _provider;
        private readonly DiscordSocketClient _client;
        private readonly CommandService _service;
        private readonly IConfiguration _configuration;

        public CommandHandler(IServiceProvider provide, DiscordSocketClient client, CommandService service, IConfiguration configuration , ILogger<DiscordClientService> logger , DataAccessLayer dataaccesslayer)
            :base(client , logger ,configuration, dataaccesslayer )
        {
            _provider = provide;
            _client = client;
            _service = service;
            _configuration = configuration;


        }
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _client.MessageReceived += OnMessageRecieved;
            _service.CommandExecuted += OnCommandExecuted;

            await _service.AddModulesAsync(Assembly.GetEntryAssembly(), _provider);
        }

        

        private Task OnCommandExecuted(Optional<CommandInfo> commandinfo, ICommandContext commandContext, IResult result)
        {
            if (!result.IsSuccess)
            {
                Console.WriteLine(result.ErrorReason);
            }

            return Task.CompletedTask;
        }

        private async Task OnMessageRecieved(SocketMessage socketMessage)
        {
            _ = Task.Run(async () =>
            {
                if (!(socketMessage is SocketUserMessage message)) return;

                if (message.Source != MessageSource.User) return;

                var argPos = 0;
                var user = message.Author as SocketGuildUser;
                var prefix = Dataaccesslayer.GetPrefix(user.Guild.Id);
                if (!message.HasStringPrefix(prefix, ref argPos) && !message.HasMentionPrefix(_client.CurrentUser, ref argPos)) return;

                var context = new SocketCommandContext(_client, message);

                await _service.ExecuteAsync(context, argPos, _provider);
                
            });
            await Task.CompletedTask;
        }
    }
}
