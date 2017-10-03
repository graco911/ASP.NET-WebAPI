using EmployeesDataAccess;
using System;
using System.Linq;

namespace WebAPISQLServer
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using (EmployeesDBEntities entities = new EmployeesDBEntities())
            {
                return entities.USERS.Any(user => user.USERNAME.Equals(username,
                    StringComparison.OrdinalIgnoreCase) && user.PASSWORD == password);
            }
        }
    }
}