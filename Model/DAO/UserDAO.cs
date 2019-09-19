using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Model.DAO
{

    public class UserDAO
    {
        Project3DBContext db = null;
        public UserDAO()
        {
            db = new Project3DBContext();
        }

        public int Insert(User entity)
        {
            if(db.Users.Count(x => x.UserName == entity.UserName) > 0)
            {
                return -1;

            } else
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            
        }

        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.UserName == userName) > 0;
        }

        public int TotalUser()
        {
            var user = db.Users.Count();
            return user;
        }

        public bool Update(User entity )
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                
                string fileName = Path.GetFileName(entity.ImageFile.FileName);
                
                user.Name = entity.Name;
                user.Email = entity.Email;
                user.Experience = entity.Experience;
                user.Hospital = entity.Hospital;
                user.Specialize = entity.Specialize;
                
                user.Images = fileName;
               
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public User GetByUsername(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        public User getUserByID(int id )
        {
            return db.Users.SingleOrDefault(x => x.ID == id);
        }

        public bool Login(string userName, string passWord)
        {
            var result = db.Users.Count(x => x.UserName == userName && x.Password == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
