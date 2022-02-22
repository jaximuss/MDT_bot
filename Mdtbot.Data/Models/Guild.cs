using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdtbot.Data.Models
{
    public class Guild
    {
        public ulong ID { get; set; }
        public string Prefix { get; set; } = "!";
    }
}
