using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ACMEWidgetActivityDL
{
    public class EmployeesRepository : IEmployees
    {
        EFDataContext _dbContext = new EFDataContext();

        //Get all employees as a list
        public List<Employees> GetEmployees()
        { 
            List<Employees> employees = _dbContext.Employees.ToList();
            return employees;
        }

        //Add a new employee
        public void AddEmployee(Employees employee)
        {
            //Adding employee to db using SP - AddEmployee
            _dbContext.Database.ExecuteSqlRaw("AddEmployee @p0, @p1, @p2, @p3, @p4", parameters: new[] {employee.FirstName,
           employee.LastName, employee.Email, employee.Activity, employee.Comments});
           
            _dbContext.SaveChanges();
        }
    }
}
