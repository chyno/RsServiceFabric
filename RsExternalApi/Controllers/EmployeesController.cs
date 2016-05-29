using Framework;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Web.Http;
using RsExternalApi.Service;
using System.Linq;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using System.Threading.Tasks;

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
            var callRes = "Success";
            var items = this.empService.GetEmployees();
            var res = items.FirstOrDefault(x => x.Id == id);
            if (res == null)
            {
                res = new Employee();
                callRes = string.Empty;
            }

            ICommonResponseService commonClient = ServiceProxy.Create<ICommonResponseService>(
                new Uri(@"fabric:/RsService/CommonObjectResponse"));
            // fabric:/RsService/CommonObjectResponse 
            var commRes = commonClient.GetCommonResponseMessage(callRes);
            Task.WaitAll(commRes);
            // fabric:/ CommonResponse / CommonResponseService
            res.Description = commRes.Result;
            return res;
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
