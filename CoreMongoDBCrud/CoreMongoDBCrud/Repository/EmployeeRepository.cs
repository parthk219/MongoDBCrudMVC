using CoreMongoDBCrud.IReopsitory;
using CoreMongoDBCrud.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMongoDBCrud.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private MongoClient _mongoClient = null; 
        private IMongoDatabase _databse = null; 
        private IMongoCollection<Employee> _employeetable = null;

        public  EmployeeRepository()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017");        // SERVER
            _databse = _mongoClient.GetDatabase("OfficeDB");                    // DB NAME
            _employeetable = _databse.GetCollection<Employee>("Employee");      // table name
        }



        public string Delete(string employeeId)
        {
            _employeetable.DeleteOne(x=>x.Id == employeeId);
            return "Deleted";
        }

        public Employee Get(string employeeId)
        {
            return _employeetable.Find(x => x.Id == employeeId).FirstOrDefault();
        }

        public Employee Get(Employee employee)
        {
            throw new NotImplementedException();
        }

        public List<Employee> Gets()
        {
            //throw new NotImplementedException();
            return _employeetable.Find(FilterDefinition<Employee>.Empty).ToList();
        }

        public Employee Save(Employee employee)
        {
            var empobj= _employeetable.Find(x => x.Id == employee.Id).FirstOrDefault();
            if(empobj==null)
            {
                _employeetable.InsertOne(employee);
            }
            else
            {
                _employeetable.ReplaceOne(x => x.Id == employee.Id,employee);
            }
            return employee;
        }
    }
}
