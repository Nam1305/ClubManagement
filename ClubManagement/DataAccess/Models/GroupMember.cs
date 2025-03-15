using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class GroupMember
{
    public int GroupMemberId { get; set; }

    public int GroupId { get; set; }

    public int UserId { get; set; }

    public DateOnly JoinedAt { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
