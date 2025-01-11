

using Microsoft.EntityFrameworkCore;
using Pok;

namespace webc.Data
{
    public class webcContext : DbContext
    {
        public webcContext (DbContextOptions<webcContext> options)
            : base(options)
        {
        }
        
        public DbSet<Pok.Pokemon> Pokemon { get; set; } = default!;
        public DbSet<Pok.Region> Region { get; set; } = default!;
        public DbSet<Pok.Item> Item { get; set; } = default!;
        public DbSet<Pok.Trainer> Trainer { get; set; } = default!;
        public DbSet<Pok.Move> Move { get; set; } = default!;
        public DbSet<Pok.USES> USES { get; set; } = default!;
        public DbSet<Pok.Carries> Carries { get; set; } = default!;
        public DbSet<Pok.Evolution> Evolution { get; set; } = default!;
    }
}
