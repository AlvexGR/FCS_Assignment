using C_Sharp_Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Training.DataAccess
{
    public static class SupplierDataAccess
    {
        /// <summary>
        /// Get all Supplier records
        /// </summary>
        /// <returns></returns>
        public static List<Supplier> GetAll()
        {
            List<Supplier> lst = new List<Supplier>();
            using (var db = new MyDbContext())
            {
                lst.Add(new Supplier { Id = 0, Name = "All suppliers" });
                lst.AddRange(db.Supplier.ToList());
            }
            return lst;
        }
    }
}
