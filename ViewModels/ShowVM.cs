using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class ShowVM
    {
        public String firstName { get; set; }
        public String lastName { get; set; }

        //[DataType(DataType.Password)]
        //public string password { get; set; }
    }
}
