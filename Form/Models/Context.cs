using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Form.Models
{
    public class Context :DbContext
    {


        public Context(DbContextOptions<Context> options) : base(options)
        {


        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Countries> Country { get; set; }
        public DbSet<Cities> City { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Cografyalar> Cografyalar { get; set; }
        public DbSet<ParamOkulTipleri> ParamOkulTipleri { get; set; }
        public DbSet<PersonelEgitimler> PersonelEgitimler { get; set; }
        public DbSet<Medya> Medya { get; set; }

    }
}
