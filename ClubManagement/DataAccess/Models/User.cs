using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    public string? StudentNumber { get; set; }

    public string Username { get; set; } = null!;

    public string? Status { get; set; }

    public virtual ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<UserClub> UserClubs { get; set; } = new List<UserClub>();
}
