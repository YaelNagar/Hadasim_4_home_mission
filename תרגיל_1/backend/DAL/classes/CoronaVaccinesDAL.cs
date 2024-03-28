using DAL.interfaces;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.classes
{
    public class CoronaVaccinesDAL: ICoronaVaccinesDAL
    {
        public List<CoronaVaccines> GetAll()
        {
            using (var db = new HMOCoronaDBContext())
            {
                return db.CoronaVaccines.ToList();
            }
        }

        public CoronaVaccines GetById(int id)
        {
            using (var db = new HMOCoronaDBContext())
            {
                return db.CoronaVaccines.First(x => x.Id == id);
            }
        }
    }
}
