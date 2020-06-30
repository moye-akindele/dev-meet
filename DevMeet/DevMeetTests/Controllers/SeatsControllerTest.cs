using DevMeet.Controllers;
using DevMeet.Services;
using DevMeetData.DTO;
using DevMeetData.Models;
using DevMeetTests.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DevMeetTests.Controllers
{
    public class SeatsControllerTest
    {
        SeatsController _controller;
        ISeatService _service;

        public SeatsControllerTest()
        {
            _service = new SeatServiceFake();
            _controller = new SeatsController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetSeats();

            // Assert
            var items = Assert.IsType<List<SeatDTO>>(okResult.Result);
            Assert.Equal(9, items.Count);
        }

        [Fact]
        public void GetSeat_UnknownIdPassed_ReturnsNullValue()
        {
            // Act
            var notFoundResult = _controller.GetSeat(10);

            // Assert
            Assert.Equal(null, notFoundResult.Result.Value);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsCorrectItem()
        {
            // Arrange
            var testId = 1;

            // Act
            var okResult = _controller.GetSeat(testId);

            // Assert
            Assert.IsType<ActionResult<SeatDTO>>(okResult.Result);
        }

        [Fact]
        public void PostSeat_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Seat testItem = new Seat()
            {
                Column = 1,
                Row = "D"
            };

            // Act
            var createdSeat = _controller.PostSeat(testItem);

            // Assert
            Assert.IsType<Task<SeatDTO>>(createdSeat);
        }

        [Fact]
        public void DeleteSeat_ExistingIdPassed_ReturnsCorrectType()
        {
            // Arrange
            var existingId = 9;

            // Act
            var removedItem = _controller.DeleteSeat(existingId);

            // Assert
            Assert.IsType<Task<ActionResult<SeatDTO>>>(removedItem);
        }
    }
}
