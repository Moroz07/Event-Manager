using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Model
{
    public class EventParticipsnt : EFModel
    {
        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 50 символов")]
        public new string Name { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Фамилия должна быть от 2 до 50 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Введите корректный email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Телефон обязателен")]
        [Phone(ErrorMessage = "Введите корректный номер телефона")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Телефон должен быть от 10 до 20 символов")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Выберите мероприятие")]
        public int EventId { get; set; }

        [ValidateNever]
        public Event Event { get; set; }
    }
}