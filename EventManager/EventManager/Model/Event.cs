using EventManager.Model;

public class Event : EFModel
{
    public DateTime EventDate { get; set; }  // было EventDate, пусть так и остаётся
    public string location { get; set; }
    public List<EventParticipsnt> Participants { get; set; } = new List<EventParticipsnt>();
}