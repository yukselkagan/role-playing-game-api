using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RolePlayingGame.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Data.Concrete.EntityFramework.Context
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Mission> Missions { get; set; }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GameContext>
        {
            public GameContext CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<GameContext>();
                var connectionString = "Server=DESKTOP-LS0EKQ4;Database=RolePlayingGameDatabase;Trusted_Connection=True;";
                builder.UseSqlServer(connectionString);
                return new GameContext(builder.Options);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(x => x.Character)
                .WithOne(x => x.Player)
                .HasForeignKey<Character>(x => x.PlayerId);

            /*
            modelBuilder.Entity<Character>()
                .HasOne(x => x.Player)
                .WithOne(x => x.Character)
                .HasForeignKey<Character>(x => x.CharacterId);
            */
        }




    }
}
