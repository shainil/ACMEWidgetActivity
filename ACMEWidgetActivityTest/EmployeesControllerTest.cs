using ACMEWidgetActivityDL;
using ACMEWidgetActivityHub.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ACMEWidgetActivityTest
{
    public class EmployeesControllerTest
    {
        EmployeeController controller;
        IEmployees employees;

        public EmployeesControllerTest()
        {
            employees = new EmployeesMock();
            controller = new EmployeeController(employees, null);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = controller.Get().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Employees>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var testEmployee = new Employees()
            {
                FirstName = "David",
                LastName = "Bahl",
                Email = "", 
                Activity = "Team Lunch",
                Comments = "Friday evening"
            };
            controller.ModelState.AddModelError("Email", "Required");
            // Act
            var badResponse = controller.Post(testEmployee);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Employees testEmployee = new Employees()
            {
                FirstName = "Thomas",
                LastName = "Smith",
                Email = "thomas@acme.com",
                Activity = "Biking",
                Comments = "Hill side biking trail"
            };
            // Act
            var createdResponse = controller.Post(testEmployee);
            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }
        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testEmployee = new Employees()
            {
                FirstName = "Thomas",
                LastName = "Smith",
                Email = "thomas@acme.com",
                Activity = "Biking",
                Comments = "Hill side biking trail"
            };
            // Act
            var createdResponse = controller.Post(testEmployee) as CreatedAtActionResult;
            var emp = createdResponse.Value as Employees;
            // Assert
            Assert.IsType<Employees>(emp);
            Assert.Equal("Biking", emp.Activity);
        }
    }
}
