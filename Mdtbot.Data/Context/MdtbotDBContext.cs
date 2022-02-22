using Mdtbot.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdtbot.Data.Context
{
    public class MdtbotDBContext : DbContext
    {
        public MdtbotDBContext(DbContextOptions options)
            :base(options)
        {
        }
         
        public DbSet<Guild> Guilds { get; set; }
    }
}
