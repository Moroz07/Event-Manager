using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.Model;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Test.UnitTests.Model
{
    public class EventTests
    {
        [Fact]
        public void Event_WithValidData_ShouldBeValid()
        {
  
            var eventItem = new Event
            {
                Name = "Концерт",
                EventDate = DateTime.Now.AddDays(30),
                location = "Москва"
            };


            var context = new ValidationContext(eventItem);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(eventItem, context, results, true);


            Assert.True(isValid);
            Assert.Empty(results);
        }

        [Fact]
        public void Event_WithMissingLocation_ShouldBeInvalid()
        {

            var eventItem = new Event
            {
                Name = "Концерт",
                EventDate = DateTime.Now.AddDays(30),
                location = null
            };

      
            var context = new ValidationContext(eventItem);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(eventItem, context, results, true);

 
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Место проведения обязательно"));
        }
    }
}
