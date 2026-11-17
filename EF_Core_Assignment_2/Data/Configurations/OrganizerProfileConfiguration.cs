using EF_Core_Assignment_2.Data;
using EF_Core_Assignment_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_Assignment_2.Data.Configurations
{
    public class OrganizerProfileConfiguration : IEntityTypeConfiguration<OrganizerProfile>
    {
        public void Configure(EntityTypeBuilder<OrganizerProfile> builder)
        {
            builder.HasOne(p => p.Organizer)
                   .WithOne(o => o.OrganizerProfile)
                   .HasForeignKey<OrganizerProfile>(
                       p => p.OrganizerId)
                   .IsRequired();
        }
    }
}
