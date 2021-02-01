using ACMEWidgetActivityDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEWidgetActivityTest
{
    public class EmployeesMock: IEmployees
    {
        private readonly List<Employees> employees;

        public EmployeesMock()
        {
            employees = new List<Employees>()
            {
                new Employees() {   FirstName = "Thomas",
                                    LastName = "Smith",
                                    Email= "thomas@acme.com",
                                    Activity="Biking",
                                    Comments="Hill side biking trail"},

                new Employees() {   FirstName = "Rick",
                                    LastName = "Dola",
                                    Email= "rick@acme.com",
                                    Activity="Game Night",
                                    Comments="Interested in Ping-pong and Foosball"},

                new Employees() {   FirstName = "John",
                                    LastName = "Kim",
                                    Email= "john@acme.com",
                                    Activity="Christmas Decoration",
                                    Comments="Hill side biking trail"},
            };
        }

        public List<Employees> GetEmployees()
        {
            return employees;
        }
        public void AddEmployee(Employees newEmployee)
        {        

            employees.Add(newEmployee);
           
        }


    }
}
