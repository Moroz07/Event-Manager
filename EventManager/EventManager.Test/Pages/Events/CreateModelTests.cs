using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventManager.Data;
using EventManager.Model;
using FluentAssertions;

namespace EventManager.Test.UnitTests.Pages.Events
{
    public class CreateModelTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void OnPost_ShouldReturnPage_WhenModelStateIsInvalid()
        {

            var context = GetDbContext();
            var pageModel = new EventManager.Pages.Events.CreateModel(context);

            pageModel.ModelState.AddModelError("Name", "Required");


            var result = pageModel.OnPost();


            result.Should().BeOfType<PageResult>();
            context.Events.Count().Should().Be(0);
        }
    }
}