using Timelinio.Models;
using Xunit;

namespace Timelinio.Tests
{
    public class ItemTest
    {
        [Fact]
        public void GetDescriptionTest()
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
    }
}