using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Timelinio.Controllers;
using Timelinio.Models;
using Xunit;
using Moq;
using System.Linq;

namespace ToDoList.Tests
{
    public class ItemsControllerTest
    {
        [Fact]
        public void Post_MethodAddsItem_Test()
        {
            // Arrange
            Mock<ITimelineRepository> mock = new Mock<ITimelineRepository>();
            mock.Setup(m => m.Timelines).Returns(new Timeline[]
                {
                    new Timeline {TimelineID = 1, Title="Cool timeline", Description = "Wash the dog" },
                    new Timeline {TimelineID = 2, Title="Timelinio is so chill", Description = "Do the dishes" },
                    new Timeline {TimelineID = 3, Title="I need sleep!", Description = "Sweep the floor" }
                }.AsQueryable());
            TimelinesController controller = new TimelinesController();
            Timeline testTimeline = new Timeline();
            testTimeline.Description = "test item";

            // Act
            controller.Create(testTimeline);
            ViewResult indexView = new TimelinesController().Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Timeline>;

            // Assert
            Assert.Contains<Timeline>(testTimeline, collection);
        }
    }
}