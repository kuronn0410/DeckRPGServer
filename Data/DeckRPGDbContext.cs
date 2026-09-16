using DeckRPGServer.Models;
using Microsoft.EntityFrameworkCore;

namespace DeckRPGServer.Data
{
    /// <summary>
    /// C#‚Ì Player ‚ÆSQLite‚Ì Players ƒe[ƒuƒ‹‚ğ‚Â‚È‚®‘‹Œû
    /// </summary>
    public class DeckRPGDbContext : DbContext
    {
        public DeckRPGDbContext(DbContextOptions<DeckRPGDbContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
    }
}