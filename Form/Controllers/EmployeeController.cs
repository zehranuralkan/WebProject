using Form.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly Context con;


        public EmployeeController(Context con)
        {
            this.con = con;
        }

        public IActionResult List()
        {
            return View(con.Employees.ToList());
        }

        [HttpGet]
        public IActionResult Update(Employees employee)
        {
            return View();
        }
      
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
    
        public List<Cografyalar> UlkeCekme()
        {
            var data = con.Cografyalar.Where(x => x.UstId == 0).ToList();
            return data;
        }

        [HttpGet]
        [Route("/Employee/CityList/{value}")]
        public List<Cografyalar> CityList(string value)
        {
            var data = con.Cografyalar.FromSqlRaw(@"Select * FROM [WebDeneme].[dbo].[Cografyalar] where UstId=" + value).ToList();
            return data;
        }

        public List<Gender> CinsiyetList()
        {
            var data = con.Genders.FromSqlRaw(@"Select * FROM [WebDeneme].[dbo].[Gender]").ToList();
            return data;

        }
       public ActionResult Sil(int id)
        {
            var silinecekCalisan = con.Employees.Find(id);
            con.Employees.Remove(silinecekCalisan);
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("/Employee/Kaydet")]
        public void Kaydet(Employees e)
        {
            var ekle = new Employees()
            {
                EmployeeName = e.EmployeeName,
                EmployeeSurname = e.EmployeeSurname,
                DateOfStartingJob = e.DateOfStartingJob,
                GenderId = e.GenderId,
                CountryId = e.CountryId,
                CityId = e.CityId,
                EmployeeAdress = e.EmployeeAdress,
            };

            con.Employees.Add(ekle);
            con.SaveChanges();
        }
 

    }
}
