using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public string? Description { get; set; }

    public int AssignedTo { get; set; }

    public int AssignedBy { get; set; }

    public int ClubId { get; set; }

    public string? Status { get; set; }

    public DateOnly? DueDate { get; set; }

    public virtual User AssignedByNavigation { get; set; } = null!;

    public virtual User AssignedToNavigation { get; set; } = null!;

    public virtual Club Club { get; set; } = null!;
}
