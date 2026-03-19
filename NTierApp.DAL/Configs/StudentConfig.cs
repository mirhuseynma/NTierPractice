
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierApp.Core.Models;

namespace NTierApp.DAL.Configs
{
    public class StudentConfig() : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                   .HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(s => s.Surname)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(s => s.Age)
                   .IsRequired();
            builder.Property(s => s.Email)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(s => s.DateOfBirth)
                   .IsRequired();
            builder.HasQueryFilter(s => !s.IsDeleted);
            builder.HasOne(s => s.Group)
                   .WithMany(g => g.Students)
                   .HasForeignKey(s => s.GroupId);


        }
    }
}
