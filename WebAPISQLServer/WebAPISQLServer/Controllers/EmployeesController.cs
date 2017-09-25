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
                return entities.Employees.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (EmployeesDBEntities entities = new EmployeesDBEntities())
            {
                var entity = entities.Employees.FirstOrDefault(e => e.ID == id);

                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format(" Employee with id = {0}, not found.", id));
                }
            }
        }

        public HttpResponseMessage Post([FromBody]Employees employee)
        {
            try
            {
                using (EmployeesDBEntities entities = new EmployeesDBEntities())
                {
                    entities.Employees.Add(employee);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);

                    message.Headers.Location = new Uri(Request.RequestUri + "/" + employee.ID.ToString());

                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (EmployeesDBEntities entities = new EmployeesDBEntities())
                {
                    var entity = entities.Employees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Employee with id = {0}, not exist to DELETE", id));
                    }
                    else
                    {
                        entities.Employees.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
