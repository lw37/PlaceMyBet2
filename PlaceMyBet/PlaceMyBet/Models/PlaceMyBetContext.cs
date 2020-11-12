using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class PlaceMyBetContext : DbContext

    {
        public DbSet<Evento> Eventos { get; set; } //Taula
        public DbSet<Mercado> Mercados { get; set; } //Taula
        public DbSet<Apuesta> Apuestas { get; set; } //Taula
        public DbSet<Usuario> Usuarios { get; set; } //Taula
        public DbSet<Cuenta> Cuentas { get; set; } //Taula

        public PlaceMyBetContext()
        {
        }

        public PlaceMyBetContext(DbContextOptions options): base(options)
        {
        }

        //Mètode de configuració
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=PlaceMyBet2;Uid=root;Pwd=''; SslMode = none");//màquina retos

            }
        }

        //Inserció inicial de dades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Evento>().HasData(new Evento(1, "Bacelona","Madrid", DateTime.Parse("Jan 5, 2020")));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(1,1.5,1.43,2.85,100,50,1));
            modelBuilder.Entity<Usuario>().HasData(new Usuario("1000@qq.com","Wei","Luo",20));
            modelBuilder.Entity<Cuenta>().HasData(new Cuenta(1, 1200,1111222233334444, "Bankia", "1000@qq.com"));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(1,true,1.43,100, DateTime.Parse("Jan 1, 2020"),1, "1000@qq.com"));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(2, true, 2.85, 100, DateTime.Parse("Jan 1, 2020"), 1, "1000@qq.com"));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(3, true, 2.85, 300, DateTime.Parse("Jan 1, 2020"), 1, "1000@qq.com"));
        }
    }
}