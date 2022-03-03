using Mdtbot.Data.Context;
using Mdtbot.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdtbot.Data
{
   public class DataAccessLayer
    {
        private readonly IDbContextFactory<MdtbotDBContext> _contextFactory;

        public DataAccessLayer(IDbContextFactory<MdtbotDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task CreateGuild(ulong id)
        {
            using var context = _contextFactory.CreateDbContext();

            if (context.Guilds.Any(x => x.ID == id))
            {
                return;
            }
            context.Add(new Guild { ID = id });

            await context.SaveChangesAsync();
        }
        public string GetPrefix(ulong Id)
        {
            using var context = _contextFactory.CreateDbContext();
            var guild = context.Guilds
               .Find(Id);

            if (guild == null)
            {
                guild = context.Add(new Guild { ID = Id }).Entity;
                context.SaveChanges();
            }
            return guild.Prefix;
        }
        //to get member maybe we just need the key which is just the id
        public string GetUsername(ulong id , string name)
        {
            using var context = _contextFactory.CreateDbContext();
            var user = context.tournamentIDs
                .Find(id);

            return user.Name;
        }
        public int GetRank(ulong id)
        {
            using var context = _contextFactory.CreateDbContext();
            var user = context.tournamentIDs
                .Find(id);

            return user.Rank;
        }
        public int GetScore(ulong id)
        {
            using var context = _contextFactory.CreateDbContext();
            var user = context.tournamentIDs
                .Find(id);

            return user.score;
        }
        public async Task SetPrefix(ulong Id , string Prefix)
        {
            using var context = _contextFactory.CreateDbContext();

            var guild = await context.Guilds
                .FindAsync(Id);

            if ( guild != null )
            {
                guild.Prefix = Prefix;
            }
            else
            {
                context.Add(new Guild { ID = Id, Prefix = Prefix });
            }

            await context.SaveChangesAsync();
        }
        public async Task JoinTournament(ulong id , string name)
        {
            using var context = _contextFactory.CreateDbContext();

            var user = await context.tournamentIDs.FindAsync(id);
            if (user != null)
            {
                user.ID = id;
                user.Name = name;
            }
            else
            {
                context.Add(new TournamentID { ID = id, Name = name });
            }
            await context.SaveChangesAsync();
        }

        public async Task DeleteGuild (ulong id)
        {
            using var context = _contextFactory.CreateDbContext();

            var guild = await context.Guilds
                .FindAsync(id);
            if (guild == null)
            {
                return;
            }

            context.Remove(guild);
            await context.SaveChangesAsync();
        }

    }
}
