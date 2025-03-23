using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public int ClubId { get; set; }

    public int? LeaderId { get; set; }

    public DateOnly CreatedAt { get; set; }

    public string Status { get; set; } = null!;

    public int? EventId { get; set; }

    public virtual Club Club { get; set; } = null!;

    public virtual ICollection<ClubTask> ClubTasks { get; set; } = new List<ClubTask>();

    public virtual Event? Event { get; set; }

    public virtual ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();

    public virtual User? Leader { get; set; }
}