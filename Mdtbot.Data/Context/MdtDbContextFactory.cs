using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdtbot.Data.Context
{
    public class MdtDbContextFactory : IDesignTimeDbContextFactory<MdtbotDBContext>
    {
        public MdtbotDBContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            var OptionsBuilder = new DbContextOptionsBuilder()
                .UseMySql(configuration.GetConnectionString("Default"),
                new MySqlServerVersion(new Version(8, 0, 28)));

            return new MdtbotDBContext(OptionsBuilder.Options);
        }
    }
}
