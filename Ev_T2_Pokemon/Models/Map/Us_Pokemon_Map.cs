using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ev_T2_Pokemon.Models.Map
{
    public class Us_Pokemon_Map : IEntityTypeConfiguration<Us_Pokemon>
    {

        public void Configure(EntityTypeBuilder<Us_Pokemon> builder)
        {
          
        builder.ToTable("PokeUser");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Reg_Usuario)
                .WithMany()
                .HasForeignKey(o => o.IdUser);
        builder.HasOne(o => o.Reg_Pokemon)
                .WithMany()
                .HasForeignKey(o => o.IdPokemon);
        }

    }
}
