using C_Sharp_Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Training.DataAccess
{
    public static class ProductDataAccess
    {
        /// <summary>
        /// Get first 50 Product records
        /// </summary>
        /// <returns>List of first 50 products</returns>
        public static List<Product> GetFirst50Product()
        {
            List<Product> lst = new List<Product>();
            using (var db = new MyDbContext())
            {
                lst = db.Product.Take(50).ToList();
            }
            return lst;
        }

        /// <summary>
        /// Search product by some criterias
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="supplierCode"></param>
        /// <param name="name"></param>
        /// <param name="supplier"></param>
        /// <param name="category"></param>
        /// <returns>List of product with limitation of 500 products</returns>
        public static List<Product> GetProduct(string barcode, string supplierCode, string name, int supplier, int category)
        {
            IEnumerable<Product> lst;
            IEnumerable<ProductSupplier> psLst;
            using (var db = new MyDbContext())
            {
                lst = db.Product;
                psLst = db.ProductSupplier;
                if (!string.IsNullOrEmpty(barcode))
                {
                    try
                    {
                        lst = lst.Where(x => x.Barcode == barcode || x.Barcode.StartsWith(barcode) || x.Barcode.EndsWith(barcode) ||
                                        x.BarcodeExtra1 == barcode || x.BarcodeExtra1.StartsWith(barcode) || x.BarcodeExtra1.EndsWith(barcode) ||
                                        x.BarcodeExtra2 == barcode || x.BarcodeExtra2.StartsWith(barcode) || x.BarcodeExtra2.EndsWith(barcode) ||
                                        x.BarcodeExtra3 == barcode || x.BarcodeExtra3.StartsWith(barcode) || x.BarcodeExtra3.EndsWith(barcode));
                    }
                    catch
                    {

                    }
                }
                if (!string.IsNullOrEmpty(supplierCode))
                {
                    IEnumerable<int> pid = psLst.Where(x => x.SupplierCode == supplierCode || x.SupplierCode.StartsWith(supplierCode) || x.SupplierCode.EndsWith(supplierCode)).Select(x => x.ProductId);
                    lst = lst.Where(x => pid.Contains(x.Id));
                }
                if (!string.IsNullOrEmpty(name))
                {
                    lst = lst.Where(x => x.Name == name || x.Name.StartsWith(name) || x.Name.EndsWith(name));
                }
                if (supplier != 0)
                {
                    IEnumerable<int> pid = psLst.Where(x => x.SupplierId == supplier).Select(x => x.ProductId);
                    lst = lst.Where(x => pid.Contains(x.Id));
                }
                if (category != 0)
                {
                    lst = lst.Where(x => x.CategoryId == category);
                }
            }
            return lst.Take(500).ToList();
        }
    }
}
