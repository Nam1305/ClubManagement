using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Message
{
    public int MessageId { get; set; }

    public int SenderId { get; set; }

    public int? ReceiverId { get; set; }

    public int ClubId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime SentAt { get; set; }

    public bool IsRead { get; set; }

    public virtual Club Club { get; set; } = null!;

    public virtual User? Receiver { get; set; }

    public virtual User Sender { get; set; } = null!;
}
