using EventManager.Model;

public class Event : EFModel
{
    public DateTime EventDate { get; set; }  
    public string location { get; set; }
    public List<EventParticipsnt> Participants { get; set; } = new List<EventParticipsnt>();
}