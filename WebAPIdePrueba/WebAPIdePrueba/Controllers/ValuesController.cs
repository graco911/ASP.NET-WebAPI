using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIdePrueba.Controllers
{
    public class ValuesController : ApiController
    {
        static List<string> empleados = new List<string>() {"Carlos", "Jose","Miguel","Roberto" };
        // GET api/values
        public IEnumerable<string> Get()
        {
            return empleados;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return empleados[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            empleados.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            empleados[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            empleados.RemoveAt(id);
        }
    }
}
