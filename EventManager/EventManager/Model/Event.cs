using System.ComponentModel.DataAnnotations;

namespace EventManager.Model
{
    public class Event : EFModel
    {
        [Required(ErrorMessage = "Дата проведения обязательна")]
        [DataType(DataType.DateTime, ErrorMessage = "Некорректная дата")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Место проведения обязательно")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Место должно быть от 3 до 200 символов")]
        public string location { get; set; }

        public List<EventParticipsnt> Participants { get; set; } = new List<EventParticipsnt>();
    }
}