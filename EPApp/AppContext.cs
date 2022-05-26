using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPApp
{
    public class AppContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptions)
        {
            dbContextOptions.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }

        public void ShowDbContents()
        {
            var users = this.Users.ToList();
            Console.WriteLine("Current database contents:");
            foreach (User user in users)
            {
                Console.WriteLine($"{user.Id}.{user.Name} - {user.Age}");
            }
        }

        public void ClearDb()
        {
            this.Users.RemoveRange(Users.Where(i => true));
            this.SaveChanges();
        }
    }
}
