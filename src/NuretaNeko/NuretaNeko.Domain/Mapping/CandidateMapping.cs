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
    public class CandidateMapping : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("Candidates", "public");
            builder.HasKey(d => d.Guid);
            builder.Property(d => d.Name)
                   .IsRequired();
            builder.Property(d => d.Phone)
                   .IsRequired();
            builder.Property(x => x.Photo)
                   .IsRequired(false);

            builder.HasOne(x => x.Resume)
                   .WithMany()
                   .HasForeignKey(x => x.ResumeId)
                   .IsRequired();
        }
    }
}
