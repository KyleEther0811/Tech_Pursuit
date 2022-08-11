namespace Tech_Pursuit.Models
{
    public class Application
    {
        public int Id { get; set; } 
        public int JobId { get; set; }
        public string UserId { get; set; }
        public string? CoverLetter { get; set; }
    }
}
