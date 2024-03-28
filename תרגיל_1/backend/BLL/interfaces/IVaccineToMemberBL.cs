using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.interfaces
{
    public interface IVaccineToMemberBL
    {
        public List<VaccineToMemberDTO> GetByIdMember(int idMember);
        public int Add(VaccineToMemberDTO vaccineToMember);
        public int CountMemberVaccine();
    }
}
