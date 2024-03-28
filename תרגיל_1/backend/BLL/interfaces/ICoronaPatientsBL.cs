using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.interfaces
{
    public interface ICoronaPatientsBL
    {
        public List<CoronaPatientsDTO> GetByIdMember(int idMember);
        public int Add(CoronaPatientsDTO coronaPatientsDTO);
        public List<KeyValuePair<int, int>> LastMonthCoronaPatients();
    }
}
