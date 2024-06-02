using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using solidariedadeAnonima.Domain.Entities;

namespace solidariedadeAnonima.Infra.Context.Mappings
{
    public class AnswersMap : IEntityTypeConfiguration<Answers>
    {
        public void Configure(EntityTypeBuilder<Answers> builder)
        {
            builder.ToTable("TB_ANSWERS");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Comment)
                .IsRequired()
                .HasColumnName("Comment")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.Image)
                .IsRequired()
                .HasColumnName("Image")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Date)
                .IsRequired()
                .HasColumnName("Date_Answer")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
