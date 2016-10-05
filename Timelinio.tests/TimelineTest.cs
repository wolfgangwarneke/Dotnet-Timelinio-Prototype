using Microsoft.AspNetCore.Identity;
using Timelinio.Data;
using Timelinio.Models;
using Timelinio.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace Timelinio.Tests
{
    public class ItemTest
    {
        public ApplicationDbContext _context;
        public UserManager<ApplicationUser> _userManager;
        public SignInManager<ApplicationUser> _signInManager;


        [Fact]
        public void GetTitleAndDescriptionTest()
        {
            //Arrange
            var timeline = new Timeline();
            timeline.Title = "Cool Test";
            timeline.Description = "It's a super cool test.";

            //Act
            var result = timeline.Title;
            var result2 = timeline.Description;
            
            //Assert
            Assert.Equal("Cool Test" + "It's a super cool test.", result + result2);
        }

        [Fact]
        public async void Get_ViewResult_Index_Test()
        {
            //Arrange
            TimelinesController controller = new TimelinesController(new ApplicationDbContext());

            //Act
            var result = await controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}