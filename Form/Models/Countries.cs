using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Form.Models
{
    [Keyless]
    public class Countries
    {
        
        public int CountryId { get; set; }
 
        public string CountryName { get; set; }
       
    }
   
}
