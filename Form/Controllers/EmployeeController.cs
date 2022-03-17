using Form.Models;
using Form.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Form.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly Context con;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public EmployeeController(Context con, IWebHostEnvironment webHostEnvironment)
        {
            this.con = con;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult List()
        {
            List<Employees> calisanlar = con.Employees.ToList();
            List<ListelemeVM> listelemeVmList = new List<ListelemeVM>();

            foreach (Employees item in calisanlar)
            {
                ListelemeVM listelemeVm = new ListelemeVM();
                listelemeVm.Calisanim = item;
                listelemeVm.CalisanUlkesi = con.Cografyalar.FirstOrDefault(x => x.UstId == 0 && x.TabloId == Convert.ToInt32(item.CountryId));
                listelemeVm.CalisanSehri = con.Cografyalar.FirstOrDefault(x => x.UstId != 0 && x.TabloId == Convert.ToInt32(item.CityId));
                listelemeVm.CalisanCinsiyet = con.Gender.FirstOrDefault(x => x.GenderId == Convert.ToInt32(item.GenderId));
                listelemeVm.MedyaId = con.Medya.FirstOrDefault(x => x.MedyaId == Convert.ToInt32(item.MedyaId));
                listelemeVmList.Add(listelemeVm);
            }

            return View(listelemeVmList);
        }

        [HttpGet]

        public IActionResult Update()
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
            var data = con.Cografyalar.Where(x => x.UstId == Convert.ToInt32(value)).ToList();
             return data;
        }

        [HttpGet]
        [Route("/Employee/EgitimGetir/{id}")]

        public List<PersonelEgitimler> EgitimGetir(int id)
        {
            var data = con.PersonelEgitimler.Where(x => x.EmployeeId == id).ToList();

            return data;

        }
        public List<Gender> CinsiyetList()
        {
            var data = con.Gender.ToList();
             return data;

        }
        public List<ParamOkulTipleri> OkulGetir()
        {
            var data = con.ParamOkulTipleri.ToList();
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
                MedyaId=e.MedyaId
                
                

            };

            con.Employees.Add(ekle);
            con.SaveChanges();


            for (int items = 0; items < e.PersonelEgitimler.Count; items++)
            {
                var ekleOkul = new PersonelEgitimler()
                {
                    EmployeeId = ekle.EmployeeId,
                    OkulId = e.PersonelEgitimler[items].OkulId,
                    OkulAdi = e.PersonelEgitimler[items].OkulAdi,
                    MezuniyetTarihi = e.PersonelEgitimler[items].MezuniyetTarihi

                };
                con.PersonelEgitimler.Add(ekleOkul);
                con.SaveChanges();

            }

        }
        [HttpGet]
        public Employees GetData(int id)
        {
    
                Employees data = con.Employees.FromSqlRaw(@"select e.EmployeeId,e.EmployeeName,e.EmployeeSurname,e.DateOfStartingJob,e.EmployeeAdress,c1.Tanim as CountryId,c2.Tanim as CityId,
                                                    g.GenderType as GenderId, m.MedyaUrl as MedyaId  from Employees e 
                                                    left join Cografyalar c1 on c1.TabloId=e.CountryId
                                                    left join Cografyalar c2 on c2.TabloId=e.CityId
                                                    left join Gender g on g.GenderId=e.GenderId 
                                                    left join Medya m on m.MedyaId=e.MedyaId where e.EmployeeId=" + id + "").FirstOrDefault();

                var egitim = con.PersonelEgitimler.Where(x => x.EmployeeId == id).ToList();
            data.PersonelEgitimler = egitim;
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
                MedyaId = update.MedyaId,


            };
            con.Employees.Update(model);
            con.SaveChanges();


             
            List<PersonelEgitimler> personelEgitim = con.PersonelEgitimler.Where(x=>x.EmployeeId==model.EmployeeId).ToList();

            List<PersonelEgitimler> personelEgitimlers = new();


            for (int items = 0; items < update.PersonelEgitimler.Count; items++)
            {

                if (update.PersonelEgitimler[items].OkulId != 0)
                {
                    personelEgitimlers.Add(update.PersonelEgitimler[items]);
                  

                }
            }

            for(int items=0;items< personelEgitim.Count; items++)
            {
                var silinecekCalisan = con.PersonelEgitimler.Find(personelEgitim[items].PersonelEgitimId);
                con.PersonelEgitimler.Remove(silinecekCalisan);
                con.SaveChanges();

            }

            for (int items = 0; items < personelEgitimlers.Count; items++)
            {
                var ekleOkul = new PersonelEgitimler()
                {
                    EmployeeId = model.EmployeeId,
                    OkulId = personelEgitimlers[items].OkulId,
                    OkulAdi = personelEgitimlers[items].OkulAdi,
                    MezuniyetTarihi = personelEgitimlers[items].MezuniyetTarihi

                };
                con.PersonelEgitimler.Add(ekleOkul);
                con.SaveChanges();
            }
        }



        [HttpPost]
        [Route("Employee/MedyaOlustur/")]
        public int MedyaOlustur(IFormFile iFormFile)
        {
            int id = 0;

            string fileName = null;
            string wwwRootPath = null;
            string path = null;
            string url = null;
            if (iFormFile != null)
            {
                wwwRootPath = _webHostEnvironment.WebRootPath;
                fileName = Path.GetFileNameWithoutExtension(iFormFile.FileName);
                string extension = Path.GetExtension(iFormFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                path = Path.Combine(wwwRootPath + "/Medya/", fileName);
                url = Path.Combine("/../Medya/", fileName);
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    iFormFile.CopyTo(fileStream);
                }
                var model2 = new Medya()
                {
                    MedyaAd = fileName,
                    MedyaUrl = url,

                };
                con.Medya.Add(model2);
                con.SaveChanges();
                id = model2.MedyaId;
            }
            return id;


        }




    }
}


