using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace prueba.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Empleados_prueba> Empleados { get; set; }
        
        public ApplicationDbContext(): base("name=LDCOM_KIELSA_QA_SLVEntities") { 
        }
    }
}