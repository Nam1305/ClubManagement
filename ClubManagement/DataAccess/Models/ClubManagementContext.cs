using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
    public virtual DbSet<ClubTask> ClubTasks { get; set; }
    public virtual DbSet<Event> Events { get; set; }
    public virtual DbSet<EventParticipant> EventParticipants { get; set; }
    public virtual DbSet<Group> Groups { get; set; }
    public virtual DbSet<GroupMember> GroupMembers { get; set; }
    public virtual DbSet<Report> Reports { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserClub> UserClubs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Rest of your model configuration remains unchanged
        // I'm only showing the resolved conflicted sections here

        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasKey(e => e.ClubId).HasName("PK__Clubs__DF4AEAB26857C28F");

            entity.Property(e => e.ClubId).HasColumnName("clubId");
            entity.Property(e => e.ClubName)
                .HasMaxLength(255)
                .HasColumnName("clubName");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.EstablishedDate).HasColumnName("establishedDate");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
        });

        // ... rest of your entity configurations ...
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}