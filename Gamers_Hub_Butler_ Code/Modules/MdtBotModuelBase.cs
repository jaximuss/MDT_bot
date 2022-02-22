

namespace Gamers_Hub_Butler__Code.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Discord;
    using Discord.Commands;
    using Discord.Rest;
    using Mdtbot.Data;

    public abstract class  MdtBotModuelBase : ModuleBase<SocketCommandContext>
    {
        public readonly DataAccessLayer DataAccessLayer;

        protected MdtBotModuelBase(DataAccessLayer dataAccessLayer)
        {
            DataAccessLayer = dataAccessLayer;
        }

        public async Task<RestUserMessage> SendEmbedAsync(string title , string description)
        {
            var builder = new EmbedBuilder()
                 .WithTitle(title)
                 .WithDescription(description);

          return await Context.Channel.SendMessageAsync(embed: builder.Build());
           
        }
    }
}
