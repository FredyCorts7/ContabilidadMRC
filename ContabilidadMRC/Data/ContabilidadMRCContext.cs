using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContabilidadMRC.Models;

namespace ContabilidadMRC.Data
{
    public class ContabilidadMRCContext : DbContext
    {
        public ContabilidadMRCContext (DbContextOptions<ContabilidadMRCContext> options)
            : base(options)
        {
        }

        public DbSet<ContabilidadMRC.Models.Customer> Customer { get; set; }

        public DbSet<ContabilidadMRC.Models.Employee> Employee { get; set; }

        public DbSet<ContabilidadMRC.Models.Bill> Bill { get; set; }

        public DbSet<ContabilidadMRC.Models.Brand> Brand { get; set; }

        public DbSet<ContabilidadMRC.Models.DetailBill> DetailBill { get; set; }

        public DbSet<ContabilidadMRC.Models.Iva> Iva { get; set; }

        public DbSet<ContabilidadMRC.Models.Product> Product { get; set; }

        public DbSet<ContabilidadMRC.Models.TypeProduct> TypeProduct { get; set; }
    }
}
