﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class ClubManagementContext : DbContext
{
    public ClubManagementContext()
    {
    }

    public ClubManagementContext(DbContextOptions<ClubManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventParticipant> EventParticipants { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserClub> UserClubs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-Q1O37LP\\DAITNA;Database=ClubManagement;User Id=sa;Password=sa;TrustServerCertificate=true;Encrypt=false;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasKey(e => e.ClubId).HasName("PK__Clubs__DF4AEAB2606D282C");

            entity.Property(e => e.ClubId).HasColumnName("clubId");
            entity.Property(e => e.ClubName)
                .HasMaxLength(255)
                .HasColumnName("clubName");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.EstablishedDate).HasColumnName("establishedDate");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__2DC7BD09C826B80C");

            entity.Property(e => e.EventId).HasColumnName("eventId");
            entity.Property(e => e.ClubId).HasColumnName("clubId");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.EventDate).HasColumnName("eventDate");
            entity.Property(e => e.EventName)
                .HasMaxLength(255)
                .HasColumnName("eventName");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");

            entity.HasOne(d => d.Club).WithMany(p => p.Events)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKEvents4410");
        });

        modelBuilder.Entity<EventParticipant>(entity =>
        {
            entity.HasKey(e => e.EventParticipantId).HasName("PK__EventPar__29D5D90BFD096731");

            entity.Property(e => e.EventParticipantId).HasColumnName("eventParticipantId");
            entity.Property(e => e.EventId).HasColumnName("eventId");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Event).WithMany(p => p.EventParticipants)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKEventParti303397");

            entity.HasOne(d => d.User).WithMany(p => p.EventParticipants)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKEventParti840496");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Report__1C9B4E2DADB23AD5");

            entity.ToTable("Report");

            entity.Property(e => e.ReportId).HasColumnName("reportId");
            entity.Property(e => e.ClubId).HasColumnName("clubId");
            entity.Property(e => e.CreatedDate).HasColumnName("createdDate");
            entity.Property(e => e.EventSummary)
                .HasMaxLength(255)
                .HasColumnName("eventSummary");
            entity.Property(e => e.MemberChanges).HasColumnName("memberChanges");
            entity.Property(e => e.ParticipationStatus)
                .HasMaxLength(255)
                .HasColumnName("participationStatus");
            entity.Property(e => e.Semester).HasColumnName("semester");

            entity.HasOne(d => d.Club).WithMany(p => p.Reports)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKReport196346");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__CD98462A853A273C");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__B19478619B24070A").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CFFD990F4EF");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("fullName");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.StudentNumber)
                .HasMaxLength(255)
                .HasColumnName("studentNumber");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__roleId__5629CD9C");
        });

        modelBuilder.Entity<UserClub>(entity =>
        {
            entity.HasKey(e => e.UserClubId).HasName("PK__userClub__C5E838BD1E2BDDED");

            entity.ToTable("userClubs");

            entity.Property(e => e.UserClubId).HasColumnName("userClubId");
            entity.Property(e => e.AppliedAt).HasColumnName("appliedAt");
            entity.Property(e => e.ApprovedAt).HasColumnName("approvedAt");
            entity.Property(e => e.ClubId).HasColumnName("clubId");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Club).WithMany(p => p.UserClubs)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKuserClubs901847");

            entity.HasOne(d => d.User).WithMany(p => p.UserClubs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKuserClubs595478");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
