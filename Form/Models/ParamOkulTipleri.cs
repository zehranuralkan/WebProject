using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Form.Models
{
    public class ParamOkulTipleri
    {
        [Key]
        public int OkulId { get; set; }
        public string Tanim { get; set; }
        public int UstId { get; set; }
    }
}
