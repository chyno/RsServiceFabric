using Framework;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Web.Http;
using RsExternalApi.Service;
using System.Linq;

namespace RsExternalApi
{
    public class EmployeesController : ApiController
    {
        private EmployeeService empService;

        public EmployeesController()
        {
            this.empService = new Service.EmployeeService();
        }
        // GET api/values 
        public IEnumerable<Employee> Get()
        {
            return this.empService.GetEmployees();
        }

        // GET api/values/5 
        public Employee Get(int id)
        {
            var items = this.empService.GetEmployees();
            return items.FirstOrDefault(x => x.Id == id);
        }

        // POST api/values 
        public void Post([FromBody]Employee value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]Employee value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}
