namespace EventManager.Model
{
    public class EventParticipsnt : EFModel
    {
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
