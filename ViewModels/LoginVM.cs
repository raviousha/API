using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class LoginVM
    {
        public String email { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
