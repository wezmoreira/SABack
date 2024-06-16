using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using solidariedadeAnonima.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solidariedadeAnonima.Infra.Context.Mappings
{
    public class CommentsMap : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.ToTable("TB_COMMENTS");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .IsRequired() 
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Card)
                .WithMany()
                .HasForeignKey(x => x.CardPrincipalId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Comment)
                .IsRequired()
                .HasColumnName("Comment")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            //builder.Property(x => x.Image)
            //    .IsRequired()
            //    .HasColumnName("Image")
            //    .HasColumnType("NVARCHAR")
            //    .HasMaxLength(100);

            builder.Property(x => x.Date)
                .IsRequired()
                .HasColumnName("Date_Comment")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()");

            //builder
            //    .HasMany(x => x.Answers)
            //    .WithMany()
            //    .UsingEntity<Dictionary<string, object>>(
            //        "Comments_Answers",
            //        item => item
            //            .HasOne<Answers>()
            //            .WithMany()
            //            .HasForeignKey("AnswerId")
            //            .HasConstraintName("FK_Comment_Answer")
            //            .OnDelete(DeleteBehavior.Cascade),
            //        order => order
            //            .HasOne<Comments>()
            //            .WithMany()
            //            .HasForeignKey("CommentId")
            //            .HasConstraintName("FK_Answer_Comment")
            //            .OnDelete(DeleteBehavior.Cascade));

            //builder
            //    .HasMany(x => x.Answers)
            //    .WithOne() 
            //    .HasForeignKey(x => x.CommentsId)
            //    .IsRequired() 
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
