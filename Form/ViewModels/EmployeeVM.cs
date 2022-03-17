using Form.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form.ViewModels
{
    public class EmployeeVM
    {
        public Employees Employees { get; set; }
        public List<Employees> EmployeesList { get; set; }
        public List<PersonelEgitimler> PersonelEgitimlerList { get; set; }
        public PersonelEgitimler PersonelEgitimler { get; set; }
        public List<string> UlkeAdi { get; set; }
        public List<int> OkulIdList { get; set; }
        public Cografyalar CografyalarUlke { get; set; }
        public Cografyalar CografyalarSehir { get; set; }
        public List<int> SilinecekOkulIdList { get; set; }
    }
}
