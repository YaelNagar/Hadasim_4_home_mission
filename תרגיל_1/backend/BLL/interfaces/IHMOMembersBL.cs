using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.interfaces
{
    public interface IHMOMembersBL
    {
        public List<HMOMembersDTO> GetAll();
        public HMOMembersDTO GetById(int id);
        public int Add(HMOMembersDTO hmoMember);
        public bool Update(HMOMembersDTO m);
        public bool Delete(int id);
    }
}
