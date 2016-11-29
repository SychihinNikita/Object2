using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.DAL.Entities;

namespace WebUI.DAL.EF
{
  public  class MobileContext :DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }

        static MobileContext()
        {
           Database.SetInitializer<MobileContext>(new StoreDbInitializer());
        }

        public MobileContext(string connectionString)
            : base(connectionString)
        {            
        }

        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<MobileContext>
        {
            protected override void Seed(MobileContext db)
            {
                db.Phones.Add(new Phone {Name = "iPhone 7", Company = "Apple", Price = 320});
                db.SaveChanges();
            }
        }
    }
}
