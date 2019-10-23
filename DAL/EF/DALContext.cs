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
        //Server = 127.0.0.1; Database=ragemp;Uid=root;Pwd=
        public DALContext() : this("Server = 173.249.30.247; Database=ragemp;Uid=rage;Pwd=M~qv20v4")
        {

        }

        public DALContext(string v)
        {
            this.v = v;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server = 173.249.30.247; Database=ragemp;Uid=rage;Pwd=M~qv20v4", ob => ob.MigrationsAssembly(typeof(DALContext).GetTypeInfo().Assembly.GetName().Name));
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
