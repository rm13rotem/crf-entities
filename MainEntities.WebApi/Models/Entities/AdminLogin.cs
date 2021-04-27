using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainEntities.WebApi.Models.Entities
{
    public class AdminLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string YearOfBirth { get; set; }
        public string DoctorNumber { get; set; }
    }
}
