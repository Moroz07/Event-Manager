namespace EventManager.Model
{
    public class Event : EFModel
    {
        public string? Description { get; set; }
        public DateTime EventDate { get; set; }
        public string location { get; set; }
        public int? EventId { get; set; }
    }
}
