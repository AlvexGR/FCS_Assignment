using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using C_Sharp_Training.Models;

namespace C_Sharp_Training.DataAccess
{
    public static class CategoryDataAccess
    {
        /// <summary>
        /// Get all Category records
        /// </summary>
        /// <returns></returns>
        public static List<Category> GetAll()
        {
            List<Category> lst = new List<Category>();
            using (var db = new MyDbContext())
            {
                lst.Add(new Category { Id = 0, Name = "All categories" });
                lst.AddRange(db.Category.ToList());
            }
            return lst;
        }
    }
}
