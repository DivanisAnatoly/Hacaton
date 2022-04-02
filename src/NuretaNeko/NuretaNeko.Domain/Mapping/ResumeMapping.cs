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
    public class ResumeMapping : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            builder.ToTable("Resumes", "public");
            builder.HasKey(d => d.Guid);
            builder.Property(d => d.Position)
                   .IsRequired();
            builder.Property(d => d.FormData)
                   .IsRequired();
            builder.Property(d => d.Score)
                   .IsRequired();
        }
    }
}
