using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string? EventName { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public DateOnly? EventDate { get; set; }

    public string? Location { get; set; }

    public int ClubId { get; set; }

    public int? Column { get; set; }

    public virtual Club Club { get; set; } = null!;

    public virtual ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();
}
