using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RsExternalApi.Service
{
    public class EmployeeService
    {
        public  IEnumerable<Employee> GetEmployees()
        {
             return new List<Employee>
            {
                new Employee
                {
                    Id =1,
                    FirstName  = "Robby",
                    LastName = "Naish"
                },
                new Employee
                {
                    Id =2,
                    FirstName  = "Roger",
                    LastName = "Federer"
                },
                new Employee
                {
                    Id =3,
                    FirstName  = "Lionel",
                    LastName = "Messi"
                },
                 new Employee
                {
                    Id =4,
                    FirstName  = "Lebron",
                    LastName = "James"
                }

            };
        }
    }
}
