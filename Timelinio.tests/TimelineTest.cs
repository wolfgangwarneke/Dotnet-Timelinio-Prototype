using Microsoft.AspNetCore.Mvc;
using Timelinio.Controllers;
using Timelinio.Models;
using Xunit;

namespace ToDoList.Tests
{
    public class ItemTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            //Arrange
            var timeline = new Timeline();
            timeline.Description = "Super cool test timeline";
            //Act
            var result = timeline.Description;

            //Assert
            Assert.Equal("Super cool test timeline", result);
        }

        //[Fact]
        //public void Get_ModelList_Index_Test()
        //{
        //    //Arrange
        //    TimelinesController controller = new TimelinesController();
        //    IActionResult actionResult = controller.Index();
        //    ViewResult indexView = controller.Index() as ViewResult;

        //    //Act
        //    var result = indexView.ViewData.Model;

        //    //Assert
        //    Assert.IsType<List<Item>>(result);
        //}
    }
}