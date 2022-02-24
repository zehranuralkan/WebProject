
using System.ComponentModel.DataAnnotations;


namespace Form.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string DateOfStartingJob { get; set; }
        public string EmployeeAdress { get; set; }
      
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int GenderId { get; set; }
      
 
    }
}
