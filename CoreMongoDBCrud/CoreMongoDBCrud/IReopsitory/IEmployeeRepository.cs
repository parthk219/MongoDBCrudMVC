using CoreMongoDBCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMongoDBCrud.IReopsitory
{
    public interface IEmployeeRepository
    {
        Employee Save(Employee employee);
        Employee Get(Employee employee);
        List<Employee> Gets();
        string Delete(string employeeId);
    }
}
