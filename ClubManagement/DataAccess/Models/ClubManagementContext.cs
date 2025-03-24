using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

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

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserClub> UserClubs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        var configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasKey(e => e.ClubId).HasName("PK__Clubs__DF4AEAB229BA44FB");

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
            entity.HasKey(e => e.TaskId).HasName("PK__ClubTask__DD5D5A423F0A0718");

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
                .HasConstraintName("FK__ClubTask__assign__31B762FC");

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.ClubTaskAssignedToNavigations)
                .HasForeignKey(d => d.AssignedTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClubTask__assign__30C33EC3");

            entity.HasOne(d => d.Club).WithMany(p => p.ClubTasks)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClubTask__clubId__32AB8735");

            entity.HasOne(d => d.Group).WithMany(p => p.ClubTasks)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__ClubTask__groupI__339FAB6E");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__2DC7BD09D2B317A3");

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
                .HasConstraintName("FK__Events__clubId__1DB06A4F");
        });

        modelBuilder.Entity<EventParticipant>(entity =>
        {
            entity.HasKey(e => e.EventParticipantId).HasName("PK__EventPar__29D5D90B4901688E");

            entity.Property(e => e.EventParticipantId).HasColumnName("eventParticipantId");
            entity.Property(e => e.EventId).HasColumnName("eventId");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Event).WithMany(p => p.EventParticipants)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventPart__event__2180FB33");

            entity.HasOne(d => d.User).WithMany(p => p.EventParticipants)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventPart__userI__208CD6FA");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__Groups__88C1034D78F7044F");

            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.ClubId).HasColumnName("clubId");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.EventId).HasColumnName("eventId");
            entity.Property(e => e.GroupName)
                .HasMaxLength(255)
                .HasColumnName("groupName");
            entity.Property(e => e.LeaderId).HasColumnName("leaderId");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Active")
                .HasColumnName("status");

            entity.HasOne(d => d.Club).WithMany(p => p.Groups)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Groups__clubId__282DF8C2");

            entity.HasOne(d => d.Event).WithMany(p => p.Groups)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Groups__eventId__2A164134");

            entity.HasOne(d => d.Leader).WithMany(p => p.Groups)
                .HasForeignKey(d => d.LeaderId)
                .HasConstraintName("FK__Groups__leaderId__29221CFB");
        });

        modelBuilder.Entity<GroupMember>(entity =>
        {
            entity.HasKey(e => e.GroupMemberId).HasName("PK__GroupMem__2E09DC7459F8ADE7");

            entity.Property(e => e.GroupMemberId).HasColumnName("groupMemberId");
            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.JoinedAt).HasColumnName("joinedAt");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupMembers)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupMemb__group__2CF2ADDF");

            entity.HasOne(d => d.User).WithMany(p => p.GroupMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupMemb__userI__2DE6D218");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Messages__4808B9937F0BB0FF");

            entity.Property(e => e.MessageId).HasColumnName("messageId");
            entity.Property(e => e.ClubId).HasColumnName("clubId");
            entity.Property(e => e.Content)
                .HasMaxLength(1000)
                .HasColumnName("content");
            entity.Property(e => e.IsRead).HasColumnName("isRead");
            entity.Property(e => e.ReceiverId).HasColumnName("receiverId");
            entity.Property(e => e.SenderId).HasColumnName("senderId");
            entity.Property(e => e.SentAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("sentAt");

            entity.HasOne(d => d.Club).WithMany(p => p.Messages)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Messages__clubId__40058253");

            entity.HasOne(d => d.Receiver).WithMany(p => p.MessageReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .HasConstraintName("FK__Messages__receiv__3F115E1A");

            entity.HasOne(d => d.Sender).WithMany(p => p.MessageSenders)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Messages__sender__3E1D39E1");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Report__1C9B4E2DCE0AEE6A");

            entity.ToTable("Report");

            entity.Property(e => e.ReportId).HasColumnName("reportId");
            entity.Property(e => e.ClubId).HasColumnName("clubId");
            entity.Property(e => e.CreatedDate).HasColumnName("createdDate");
            entity.Property(e => e.EventSummary)
                .HasMaxLength(255)
                .HasColumnName("eventSummary");
            entity.Property(e => e.MemberChanges)
                .HasMaxLength(255)
                .HasColumnName("memberChanges");
            entity.Property(e => e.ParticipationStatus)
                .HasMaxLength(255)
                .HasColumnName("participationStatus");
            entity.Property(e => e.Semester)
                .HasMaxLength(50)
                .HasColumnName("semester");

            entity.HasOne(d => d.Club).WithMany(p => p.Reports)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Report__clubId__245D67DE");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__CD98462AC390CE00");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__B1947861B1B85AA4").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CFF8656A1ED");

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
                .HasConstraintName("FK__Users__roleId__17036CC0");
        });

        modelBuilder.Entity<UserClub>(entity =>
        {
            entity.HasKey(e => e.UserClubId).HasName("PK__userClub__C5E838BD2FFEDAF1");

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
                .HasConstraintName("FK__userClubs__clubI__1AD3FDA4");

            entity.HasOne(d => d.User).WithMany(p => p.UserClubs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__userClubs__userI__19DFD96B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
