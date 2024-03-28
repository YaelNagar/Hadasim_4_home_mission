using DAL.interfaces;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.classes
{
    public class VaccineToMemberDAL: IVaccineToMemberDAL
    {
        public List<VaccineToMember> GetAll()
        {
            using (var db = new HMOCoronaDBContext())
            {
                return db.VaccineToMember.ToList();
            }
        }

        public List<VaccineToMember> GetByIdMember(int idMember)
        {
            using (var db = new HMOCoronaDBContext())
            {
                return db.VaccineToMember.Where(x => x.IdMember == idMember).ToList();
            }
        }

        public int Add(VaccineToMember v)
        {
            using (var db = new HMOCoronaDBContext())
            {
                db.VaccineToMember.Add(v);
                db.SaveChanges();
                return v.Id;
            }
        }
    }
}
