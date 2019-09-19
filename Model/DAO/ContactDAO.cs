using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ContactDAO
    {
        Project3DBContext db = null;
        public ContactDAO()
        {
            db = new Project3DBContext();
        }

        public int SendContact(Contact entity)
        {
            db.Contacts.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public List<User> SearchDoctor(string searchDoctor)
        {
            var model =  db.Users.Where(x => x.IsDoctor == true);
                       
                        

            if (!String.IsNullOrEmpty(searchDoctor))
            {
                model = model.Where(x => x.Name.Contains(searchDoctor));
                return model.ToList();
            }
            return model.ToList();
        }
    }
}
