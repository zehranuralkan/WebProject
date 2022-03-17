using System.ComponentModel.DataAnnotations;

namespace Form.Models
{
 
    public class PersonelEgitimler
    {
        [Key]
        public int PersonelEgitimId { get; set; }
        public int EmployeeId { get; set; }
        public int OkulId { get; set; }
        public string OkulAdi { get; set; }
        public string MezuniyetTarihi { get; set; }

    }
}
