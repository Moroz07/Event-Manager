using System.ComponentModel.DataAnnotations;

namespace EventManager.Model
{
    public class EFModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Наименование обязательно")]
        public string Name { get; set; }
    }
}
