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
            //return View(con.Employees.ToList());
            var data = con.Employees.FromSqlRaw(@"select e.EmployeeId,e.EmployeeName,e.EmployeeSurname,e.DateOfStartingJob,e.EmployeeAdress,c.Tanim as CountryId,v.Tanim as CityId,g.GenderType as GenderId from Employees e

                                                LEFT OUTER JOIN Cografyalar c ON c.TabloId=e.CountryId 
                                                LEFT OUTER JOIN Cografyalar v ON v.TabloId=e.CityId
                                                LEFT OUTER JOIN Gender g ON g.GenderId=e.GenderId").ToList();

            return View(data);
        }


        [HttpGet]

        public IActionResult Update()
        {
            return View();
        }
        //public Employees 
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
        public IActionResult Sil(int id)
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
        [HttpGet]
        public Employees GetData(int id)
        {
            var data = con.Employees.FromSqlRaw(@"select e.EmployeeId,e.EmployeeName,e.EmployeeSurname,e.DateOfStartingJob,e.EmployeeAdress,c1.Tanim as CountryId,c2.Tanim as CityId,
                                                g.GenderType as GenderId  from Employees e 
                                                left join Cografyalar c1 on c1.TabloId=e.CountryId
                                                left join Cografyalar c2 on c2.TabloId=e.CityId
                                                left join Gender g on g.GenderId=e.GenderId where e.EmployeeId="+id+"").FirstOrDefault();
            return data;
        }
        [Route(" /Employee/Update/{id}")]
        public IActionResult Update(int id)
        {

            return View();
        }
        [HttpPost]
        [Route("/Employee/UpdateKayit")]
        public void UpdateKayit(Employees update)
        {

            var model = new Employees()
            {
                EmployeeId = update.EmployeeId,
                EmployeeName = update.EmployeeName,
                EmployeeSurname = update.EmployeeSurname,
                DateOfStartingJob = update.DateOfStartingJob,
                EmployeeAdress = update.EmployeeAdress,
                CountryId = update.CountryId,
                CityId = update.CityId,
                GenderId = update.GenderId,

            };
            con.Employees.Update(model);
            con.SaveChanges();
        }
    }
}
