using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Eticaret.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }
        [DisplayName("Ürün Fiyat")]
        public double Price { get; set; }
        [DisplayName("Ürün Stok")]
        public int Stock { get; set; }
        public string Image { get; set; }
        [DisplayName("Onay Durumu")]
        public bool IsApproved { get; set; }
        [DisplayName("Anasayfa")]
        public bool IsHome { get; set; }

        // tablo ismi arada boşluk olmadan alınacak anahtar kelime
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}