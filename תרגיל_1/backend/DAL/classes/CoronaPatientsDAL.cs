using DAL.interfaces;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.classes
{
    public class CoronaPatientsDAL: ICoronaPatientsDAL
    {
        public List<CoronaPatients> GetAll()
        {
            using (var db = new HMOCoronaDBContext())
            {
                return db.CoronaPatients.ToList();
            }
        }

        public List<CoronaPatients> GetByIdMember(int idMember)
        {
            using (var db = new HMOCoronaDBContext())
            {
                return db.CoronaPatients.Where(x => x.IdMember == idMember).ToList();
            }
        }

        public int Add(CoronaPatients p)
        {
            using (var db = new HMOCoronaDBContext())
            {
                db.CoronaPatients.Add(p);
                db.SaveChanges();
                return p.Id;
            }
        }
    }
}
