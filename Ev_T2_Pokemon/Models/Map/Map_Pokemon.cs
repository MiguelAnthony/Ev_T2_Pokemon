using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ev_T2_Pokemon.Models.Map
{
    public class Map_Pokemon : IEntityTypeConfiguration<Reg_Pokemon>
    {
            
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Reg_Pokemon> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Us_Pokemon)
                .WithMany()
                .HasForeignKey(o => o.Id);


        }

    }
}
