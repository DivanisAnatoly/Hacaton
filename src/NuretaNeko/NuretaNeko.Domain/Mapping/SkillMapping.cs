using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NuretaNeko.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.Domain.Mapping
{
    public class SkillMapping : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills", "public");
            builder.HasKey(d => d.Guid);
            builder.Property(d => d.Name)
                   .IsRequired();
            builder.Property(d => d.Code)
                   .IsRequired();
            builder.Property(d => d.Priority)
                   .IsRequired();
        }
    }
}
