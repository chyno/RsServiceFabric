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
        public async Task<Employee> Get(int id)
        {
            var callRes = "Success";
            Employee employee;
            ICommonResponseService commonClient = ServiceProxy.Create<ICommonResponseService>(
                 new Uri(@"fabric:/RsService/CommonObjectResponse"));

            if (id == 13)
            {
                try
                {
                    var excep = await commonClient.GenerateTestException();
                    employee = new Employee { Description = "This should not be set", Id = id };
                }
                catch (System.Exception ex)
                {
                    var message = ex.InnerException.Message;

                    var source = ex.InnerException.Source;
                    employee = new Employee { Description = string.Format("Message : {0}. Source {1}", message, source), Id = id };
                }
                    
               

            }
            else
            {
                employee = empService.GetEmployees().Where(x => x.Id == id).FirstOrDefault();
                if (employee == null)
                {
                    employee = new Employee();
                    callRes = string.Empty;
                }
                this.SetCommonResponseDescription(ref employee, callRes, commonClient);
               
            }

            return employee;
        }

        private void SetCommonResponseDescription(ref Employee employee, string callRes, ICommonResponseService commonClient)
        {
            
            // fabric:/RsService/CommonObjectResponse 
            var commRes = commonClient.GetCommonResponseMessage(callRes);
            Task.WaitAll(commRes);
            // fabric:/ CommonResponse / CommonResponseService
            employee.Description = commRes.Result;
           
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
