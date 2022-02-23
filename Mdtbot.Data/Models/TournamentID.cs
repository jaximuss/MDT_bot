using System.ComponentModel.DataAnnotations;

namespace Mdtbot.Data.Models
{
    public class TournamentID
    {
        
        public ulong ID  { get; set; }
        public string  Name  { get; set; }
        public int Rank  { get; set; }
        public int score { get; set; }
    }
}
