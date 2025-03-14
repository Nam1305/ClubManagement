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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=THANG\\SQLEXPRESS13;Database=ClubManagement;User Id=sa;Password=123;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<ClubTask>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__ClubTask__DD5D5A42A5D7373B");

            entity.ToTable("ClubTask");

            entity.Property(e => e.TaskId).HasColumnName("taskId");
            entity.Property(e => e.AssignedBy).HasColumnName("assignedBy");
            entity.Property(e => e.AssignedTo).HasColumnName("assignedTo");
            entity.Property(e => e.ClubId).HasColumnName("clubId");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.DueDate).HasColumnName("dueDate");
            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TaskName)
                .HasMaxLength(255)
                .HasColumnName("taskName");

            entity.HasOne(d => d.AssignedByNavigation).WithMany(p => p.ClubTaskAssignedByNavigations)
                .HasForeignKey(d => d.AssignedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClubTask__assign__4F7CD00D");

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.ClubTaskAssignedToNavigations)
                .HasForeignKey(d => d.AssignedTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClubTask__assign__4E88ABD4");

            entity.HasOne(d => d.Club).WithMany(p => p.ClubTasks)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClubTask__clubId__5070F446");

            entity.HasOne(d => d.Group).WithMany(p => p.ClubTasks)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__ClubTask__groupI__5165187F");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__2DC7BD095F68C07D");

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
            entity.HasKey(e => e.EventParticipantId).HasName("PK__EventPar__29D5D90BFB759176");

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

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__Groups__88C1034D90D2FFF7");

            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.ClubId).HasColumnName("clubId");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.GroupName)
                .HasMaxLength(255)
                .HasColumnName("groupName");
            entity.Property(e => e.LeaderId).HasColumnName("leaderId");

            entity.HasOne(d => d.Club).WithMany(p => p.Groups)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Groups__clubId__46E78A0C");

            entity.HasOne(d => d.Leader).WithMany(p => p.Groups)
                .HasForeignKey(d => d.LeaderId)
                .HasConstraintName("FK__Groups__leaderId__47DBAE45");
        });

        modelBuilder.Entity<GroupMember>(entity =>
        {
            entity.HasKey(e => e.GroupMemberId).HasName("PK__GroupMem__2E09DC74E83B9718");

            entity.Property(e => e.GroupMemberId).HasColumnName("groupMemberId");
            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.JoinedAt).HasColumnName("joinedAt");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupMembers)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupMemb__group__4AB81AF0");

            entity.HasOne(d => d.User).WithMany(p => p.GroupMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupMemb__userI__4BAC3F29");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Report__1C9B4E2D07047EAC");

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
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__CD98462AE3805767");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__B19478610DA8DA64").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CFF7C2F2708");

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
                .HasConstraintName("FK__Users__roleId__440B1D61");
        });

        modelBuilder.Entity<UserClub>(entity =>
        {
            entity.HasKey(e => e.UserClubId).HasName("PK__userClub__C5E838BD534FAF11");

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
