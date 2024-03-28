using DAL.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.interfaces
{
    public interface ICoronaVaccinesDAL
    {
        public List<CoronaVaccines> GetAll();
        public CoronaVaccines GetById(int id);
    }
}
