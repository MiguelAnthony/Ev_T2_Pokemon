using Ev_T2_Pokemon.Models.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ev_T2_Pokemon.Models
{
    public class Ev_T2_Pokemon_Context : DbContext
    {
        public DbSet<Reg_Pokemon> Reg_Pokemon { get; set; }
        public DbSet<Reg_Usuario> Reg_Usuario { get; set; }
        public DbSet<Us_Pokemon> Us_Pokemon { get; set; }

        public Ev_T2_Pokemon_Context(DbContextOptions<Ev_T2_Pokemon_Context> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Esto se hace por cada tabla de base de datos
            modelBuilder.ApplyConfiguration(new Map_Pokemon());
            modelBuilder.ApplyConfiguration(new Reg_Usuario_Map());
            modelBuilder.ApplyConfiguration(new Us_Pokemon_Map());
        }
    }
}