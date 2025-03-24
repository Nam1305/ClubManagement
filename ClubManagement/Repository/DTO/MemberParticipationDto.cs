namespace Repository.DTO
{
    public class MemberParticipationDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string StudentNumber { get; set; }
        public string Email { get; set; }
        public double ParticipationPercentage { get; set; }
        public string ActivityLevel { get; set; }
        public string EventParticipationStatus { get; set; } 
    }
}