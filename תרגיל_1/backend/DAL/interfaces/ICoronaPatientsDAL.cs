using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaces
{
    public interface ICoronaPatientsDAL
    {
        public List<CoronaPatients> GetAll();
        public List<CoronaPatients> GetByIdMember(int idMember);
        public int Add(CoronaPatients p);
    }
}
