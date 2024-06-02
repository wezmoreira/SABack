using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using solidariedadeAnonima.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace solidariedadeAnonima.Infra.Context.Mappings
{
    public class CardMap : IEntityTypeConfiguration<CardPrincipal>
    {
        public void Configure(EntityTypeBuilder<CardPrincipal> builder)
        {
            builder.ToTable("TB_CARD");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.ImageLarge)
                .IsRequired()
                .HasColumnName("Image_Large")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.ImageOriginal)
                .IsRequired()
                .HasColumnName("Image_Original")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.ImagePortrait)
                .IsRequired()
                .HasColumnName("Image_Portrait")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.ImageLandscape)
                .IsRequired()
                .HasColumnName("Image_Landscape")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.ImageTiny)
                .IsRequired()
                .HasColumnName("Image_Tiny")
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
