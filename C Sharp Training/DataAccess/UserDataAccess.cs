using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Sharp_Training.Models;
using Npgsql;

namespace C_Sharp_Training.DataAccess
{
    public static class UserDataAccess
    {
        /// <summary>
        /// Verify user by the pin
        /// </summary>
        /// <param name="pin"> the Input pin</param>
        /// <returns>True if the pin belongs to some user else False</returns>
        public static bool VerifyUserByPin(string pin)
        {
            bool ans = true;
            using (var db = new MyDbContext())
            {
                int total = db.Users.Where(x => x.Pin == pin).Count();
                if (total == 0)
                {
                    ans = false;
                }
            }
            return ans;
        }
    }
}
