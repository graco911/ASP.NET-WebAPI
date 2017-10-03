using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeesService.Controllers
{
    public class EmployeeController : ApiController
    {
        [Authorize]
        public IEnumerable<Employees> Get()
        {
            using (EmployeesDBEntities entities = new EmployeesDBEntities())
            {
                return entities.Employees.ToList();
            }
        }
    }
}
