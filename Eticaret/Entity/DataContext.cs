using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eticaret.Entity
{
    // DbContext ten türetiriz bunun için nugets tan entity.framework paketini indirmeliyiz
    public class DataContext:DbContext
    {
        // ConnectionStrings işlemi bittikten sonra ctor oluştururuz
        // ctor yazıp iki kere taba bas

        public DataContext() : base("dataConnection")
        {
            // Test verileri olarak aldığımız dataInıtializer ı aktif ediyoruz
            // Database.SetInitializer(new DataInitializer());

        }
        //DbSet diyip context in kullandığı entityleri ekliyoruz
        public DbSet<Product> Products { get; set; }
        public DbSet <Category> Categories { get; set; }
        // bu işlem bittikten sonra Web.config de ConnectionStrings hazırlarız
    }
}