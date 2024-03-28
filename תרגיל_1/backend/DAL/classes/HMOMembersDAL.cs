using DAL.interfaces;
using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.classes
{
    public class HMOMembersDAL: IHMOMembersDAL
    {
        public List<Hmomembers> GetAll()
        {
            using (var db = new HMOCoronaDBContext())
            {
                return db.Hmomembers.ToList();
            }
        }

        public Hmomembers GetById(int id)
        {
            using (var db = new HMOCoronaDBContext())
            {
                return db.Hmomembers.FirstOrDefault(x => x.Id == id);
            }
        }

        public int Add(Hmomembers m)
        {
            using (var db = new HMOCoronaDBContext())
            {
                db.Hmomembers.Add(m);
                db.SaveChanges();
                return m.Id;
            }
        }

        public bool Update(Hmomembers m)
        {
            using (var db = new HMOCoronaDBContext())
            {
                Hmomembers member = db.Hmomembers.First(x => x.Id == m.Id);
                if (member == null)
                    return false;
                member.Identity= m.Identity;
                member.FirstName= m.FirstName;
                member.LastName= m.LastName;
                member.BirthDate= m.BirthDate;
                member.Telephone= m.Telephone;
                member.Phone= m.Phone;
                member.Address= m.Address;
                db.SaveChanges();
                return true;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new HMOCoronaDBContext())
            {
                Hmomembers m = db.Hmomembers.First(x => x.Id == id);
                if (m == null)
                    return false;
                db.Hmomembers.Remove(m);
                db.SaveChanges();
                return true;
            }
        }
    }
}
