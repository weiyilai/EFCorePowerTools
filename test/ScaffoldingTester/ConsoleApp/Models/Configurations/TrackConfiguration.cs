﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp.Models.Configurations;

public partial class TrackConfiguration : IEntityTypeConfiguration<Track>
{
    public void Configure(EntityTypeBuilder<Track> entity)
    {
        entity.ToTable("Track");

        entity.HasIndex(e => e.AlbumId, "IFK_TrackAlbumId");

        entity.HasIndex(e => e.GenreId, "IFK_TrackGenreId");

        entity.HasIndex(e => e.MediaTypeId, "IFK_TrackMediaTypeId");

        entity.Property(e => e.Composer).HasMaxLength(220);
        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(200);
        entity.Property(e => e.UnitPrice).HasColumnType("numeric(10, 2)");

        entity.HasOne(d => d.Album).WithMany(p => p.Tracks)
            .HasForeignKey(d => d.AlbumId)
            .HasConstraintName("FK_TrackAlbumId");

        entity.HasOne(d => d.Genre).WithMany(p => p.Tracks)
            .HasForeignKey(d => d.GenreId)
            .HasConstraintName("FK_TrackGenreId");

        entity.HasOne(d => d.MediaType).WithMany(p => p.Tracks)
            .HasForeignKey(d => d.MediaTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_TrackMediaTypeId");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Track> modelBuilder);
}
