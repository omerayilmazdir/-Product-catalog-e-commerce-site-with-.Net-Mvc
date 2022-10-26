using Eticaret.Entity;
using Eticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.Controllers
{
    public class HomeController : Controller
    {
        // Veritabanını bağlıyoruz
        DataContext context = new DataContext();


        // GET: Home
        public ActionResult Index()
        {
            // ürünleri gönderiyoruz
            // index view ına gidip model olarak ekliyoruz
            // ana sayfa onaylı ve onaylı listeler Index sayfasına gitsin

            var urunler = context.Products
                .Where(i => i.IsHome && i.IsApproved)
                .Select(i=> new ProductModel {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description = i.Description.Length>50?i.Description.Substring(0,47)+"...":i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    Image = i.Image,
                    CategoryId = i.CategoryId
                }).ToList();

            return View(urunler);
        }
        // içeriden gelen id ile ürün id si eşit olanı çek FirstOrDefault kullan
        public ActionResult Details(int id)
        {
            return View(context.Products.Where(i => i.Id == id).FirstOrDefault());
        }
        // sadece onaylı ürünler gitsin
        // asqueryable ile sorgu çalıştırılmaz filtrelenir
        // view de to list yapıp sorguyu çalıştırırız
        public ActionResult List(int?id)
        {
            var urunler = context.Products
                .Where(i => i.IsApproved)
                .Select(i => new ProductModel
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    // eğer resim boşsa 1.jpg yi ata
                    Image = i.Image ?? "1.jpg",
                    CategoryId = i.CategoryId
                }).AsQueryable();
            // kullanıcının gördüğü id boş değilse filtreme işlemi eklenir
            // yani bu kısımda istenilen kategoriye ait ürünler gelir 
            // kategoriye tıklandığında kendisine ait ürünleri gösterir
            if (id != null)
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }

            return View(urunler.ToList());
        }

        // kategorileri partial view olarak home controller a ekliyoruz
        public PartialViewResult GetCategories()
        {
            return PartialView(context.Categories.ToList());
        }
    }
}