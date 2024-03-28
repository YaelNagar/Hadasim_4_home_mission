using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaces
{
    public interface IHMOMembersDAL
    {
        public List<Hmomembers> GetAll();
        public Hmomembers GetById(int id);
        public int Add(Hmomembers m);
        public bool Update(Hmomembers m);
        public bool Delete(int id);
    }
}
