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
    public class SkillOptionMapping : IEntityTypeConfiguration<SkillOption>
    {
        public void Configure(EntityTypeBuilder<SkillOption> builder)
        {
            builder.ToTable("SkillOptions", "public");
            builder.HasKey(d => d.Guid);
            builder.Property(d => d.OptionKey)
                   .IsRequired();
            builder.Property(d => d.Value)
                   .IsRequired();
            builder.Property(d => d.Score)
                   .IsRequired();

            builder.HasOne(x => x.Skill)
                   .WithMany()
                   .HasForeignKey(x => x.SkillId)
                   .IsRequired();
        }
    }
}
