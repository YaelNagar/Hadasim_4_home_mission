using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaces
{
    public interface IVaccineToMemberDAL
    {
        public List<VaccineToMember> GetAll();
        public List<VaccineToMember> GetByIdMember(int idMember);
        public int Add(VaccineToMember v);
    }
}
