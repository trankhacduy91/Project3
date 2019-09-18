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
    }
}
