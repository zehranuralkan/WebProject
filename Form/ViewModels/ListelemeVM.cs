using Form.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form.ViewModels
{
    public class ListelemeVM
    {
        public Employees Calisanim { get; set; }
        public Cografyalar CalisanUlkesi { get; set; }
        public Cografyalar CalisanSehri { get; set; }
        public Gender CalisanCinsiyet { get; set;} 
        public Medya MedyaId { get; set; }

    }
}
