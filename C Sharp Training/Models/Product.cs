using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Product
    {
        public Product()
        {
            DeletedItem = new HashSet<DeletedItem>();
            Inventory = new HashSet<Inventory>();
            InverseCartonProduct = new HashSet<Product>();
            Orderline = new HashSet<Orderline>();
            PriceSchedule = new HashSet<PriceSchedule>();
            ProductGroup = new HashSet<ProductGroup>();
            ProductPromotionProductId1Navigation = new HashSet<ProductPromotion>();
            ProductPromotionProductId2Navigation = new HashSet<ProductPromotion>();
            ProductQuicklist = new HashSet<ProductQuicklist>();
            ProductSupplier = new HashSet<ProductSupplier>();
            Reportline = new HashSet<Reportline>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NameChinese { get; set; }
        public float PriceUnit { get; set; }
        public float? ItemOnHand { get; set; }
        public int? CategoryId { get; set; }
        public string Barcode { get; set; }
        public string BarcodeExtra1 { get; set; }
        public string BarcodeExtra2 { get; set; }
        public string BarcodeExtra3 { get; set; }
        public float? PriceCold { get; set; }
        public DateTime? LastEdit { get; set; }
        public bool? Enable { get; set; }
        public bool? IsCarton { get; set; }
        public bool? IsOpenPrice { get; set; }
        public bool? IsNonTaxable { get; set; }
        public float? CartonQuantity { get; set; }
        public int? CartonProductId { get; set; }
        public bool? DoesSaleByWeight { get; set; }
        public Guid? Uuid { get; set; }
        public int? Type { get; set; }
        public int? PacketGroupId { get; set; }
        public string WeightScaleId { get; set; }

        public Product CartonProduct { get; set; }
        public Category Category { get; set; }
        public ICollection<DeletedItem> DeletedItem { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
        public ICollection<Product> InverseCartonProduct { get; set; }
        public ICollection<Orderline> Orderline { get; set; }
        public ICollection<PriceSchedule> PriceSchedule { get; set; }
        public ICollection<ProductGroup> ProductGroup { get; set; }
        public ICollection<ProductPromotion> ProductPromotionProductId1Navigation { get; set; }
        public ICollection<ProductPromotion> ProductPromotionProductId2Navigation { get; set; }
        public ICollection<ProductQuicklist> ProductQuicklist { get; set; }
        public ICollection<ProductSupplier> ProductSupplier { get; set; }
        public ICollection<Reportline> Reportline { get; set; }
    }
}
