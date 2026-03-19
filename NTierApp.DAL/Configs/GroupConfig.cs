using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierApp.Core.Models;


namespace NTierApp.DAL.Configs
{
    public class GroupConfig : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(g => g.Description)
                .HasMaxLength(500);
            builder.HasMany(g => g.Students)
                   .WithOne(s => s.Group)
                   .HasForeignKey(s => s.GroupId);
        }
    }
}
