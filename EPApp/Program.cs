using System;
using System.Linq;

namespace EPApp
{
    class Program
    {
        

        public static void Main(string[] Args)
        {
            using(AppContext db = new AppContext())
            {
                db.Users.Add(new User { Name = "King", Age = 56 });
                db.Users.Add(new User { Name = "Korchhar", Age = 44 });
                db.SaveChanges();

                db.ShowDbContents();

                db.Users.Remove((User)db.Users.Where(user => user.Name == "Korchhar").First());
                db.SaveChanges();

                db.ShowDbContents();

                User someUser = db.Users.ToList().First();
                someUser.Age = 99;
                db.Users.Update(someUser);

                db.ShowDbContents();

            }
        }
    }
}
