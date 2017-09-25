using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeesDataAccess;

namespace WebAPISQLServer.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employees> Get()
        {
            using (EmployeesDBEntities entities = new EmployeesDBEntities())
            {
                return entities.Employees.ToList() ;
            }
        }

        public Employees Get(int id)
        {
            using (EmployeesDBEntities entities = new EmployeesDBEntities())
            {
                return entities.Employees.FirstOrDefault(e => e.ID == id);
            }
        }
    }
}
