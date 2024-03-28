using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.interfaces
{
    public interface ICoronaVaccinesBL
    {
        public List<CoronaVaccinesDTO> GetAll();
        public CoronaVaccinesDTO GetById(int id);
    }
}
