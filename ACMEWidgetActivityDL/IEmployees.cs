using System;
using System.Collections.Generic;
using System.Text;

namespace ACMEWidgetActivityDL
{
    public interface IEmployees
    {
        List<Employees> GetEmployees();
        void AddEmployee(Employees employee);
    }
}
