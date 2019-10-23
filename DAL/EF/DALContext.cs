using DAL.EF.TableClasses;
using DAL.TableClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DAL.EF
{
    public class DALContext : DbContext
    {
        string v;
        public DALContext() : this("Removed conn string for github")
        {

        }

        public DALContext(string v)
        {
            this.v = v;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Removed conn string for github", ob => ob.MigrationsAssembly(typeof(DALContext).GetTypeInfo().Assembly.GetName().Name));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Account> Accounts { get; set; } //Without this line, the Player class will not be translated to MySQL and the context will not contain a list of all players from the database.
        public DbSet<Character> Characters { get; set; } //Without this line, the Player class will not be translated to MySQL and the context will not contain a list of all players from the database.
        public DbSet<Building> Buildings { get; set; }
        public DbSet<DroppedItem> DroppedItems { get; set; }
        public DbSet<Faction> Factions { get; set; }

    }
}
