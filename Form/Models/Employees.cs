﻿                                                        
using Microsoft.EntityFrameworkCore;
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
      
        public string CountryId { get; set; }
        public string CityId { get; set; }
        public string GenderId { get; set; }
      
 
    }
}
