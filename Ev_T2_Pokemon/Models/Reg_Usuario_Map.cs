using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ev_T2_Pokemon.Models
{
    public class Reg_Usuario_Map : IEntityTypeConfiguration<Reg_Usuario>
    {
        public void Configure(EntityTypeBuilder<Reg_Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.Us_Pokemon)
                .WithOne()
                .HasForeignKey(o => o.Id);
        }
    }
}
