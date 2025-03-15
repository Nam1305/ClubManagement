using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Club
{
    public int ClubId { get; set; }

    public string? ClubName { get; set; }

    public string? Description { get; set; }

    public DateOnly? EstablishedDate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<ClubTask> ClubTasks { get; set; } = new List<ClubTask>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<UserClub> UserClubs { get; set; } = new List<UserClub>();
}
