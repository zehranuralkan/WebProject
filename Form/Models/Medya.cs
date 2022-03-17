using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Form.Models
{
    public class Medya
    {
        [Key]
        public int MedyaId { get; set; }
        public string MedyaUrl { get; set; }
        public string MedyaAd { get; set; }
    }
}
