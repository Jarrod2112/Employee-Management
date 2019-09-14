using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Stores specifications of the way the data is being manipulated.
namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Aaron", Department = Dept.IT, Email = "Jake@Gmail.com"},
                new Employee() { Id = 2, Name = "Dustin", Department = Dept.IT, Email = "Dustin@Gmail.com"},
                new Employee() { Id = 3, Name = "Jake", Department = Dept.IT, Email = "Jarrod@Gmail.com"}
            };
        }
        
        public Employee Add(Employee employee)
        {
           employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            // FirstOrDefault() used when we have to check if there is an element.
            // First() if we know there is an element.
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if(employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {

            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;

            }
            return employee;
        }
    }
}
