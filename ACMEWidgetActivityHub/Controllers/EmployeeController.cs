using ACMEWidgetActivityDL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACMEWidgetActivityHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployees employeesRepository { get; set; }
        public EmployeeController(IEmployees employeesRepository, IConfiguration configuration)
        {
            this.employeesRepository = employeesRepository;
            //setting connection string for Entity DbContext
            var connectionString = configuration.GetConnectionString("ConnStr");
            EFDataContext.SetConnectionString(connectionString);
        }

        // GET
        // api/Employee

        /// <summary>
        /// Retrieves all the employees
        /// </summary>         
        /// <returns>A response with employee list</returns>
        /// <response code="200">Returns the employee list</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet]
        public ActionResult<Employees> Get()
        {
            List<Employees> employees = employeesRepository.GetEmployees();
            return Ok(employees);
        }


        // POST
        // api/Employee/

        /// <summary>
        /// Create a new employee
        /// </summary>
        ///   /// <param name="FirstName">First Name</param>
        /// <param name="LastName">Last Name</param>
        /// <param name="Email">Employee's email</param>
        /// <param name="Activity">Employees activity</param>
        /// <param name="Comments">Comments for activity</param>    
        /// <param name="request">Request model</param>
        /// <returns>A response with new employee</returns>
        /// <response code="200">Returns the employee list</response>
        /// <response code="201">A response as creation of employee</response>
        /// <response code="400">For bad request</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpPost]
        public ActionResult Post(Employees employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            employeesRepository.AddEmployee(employee);         

            return CreatedAtAction("Get", new { id = employee.EmployeeID }, employee);
        }
    }
}
