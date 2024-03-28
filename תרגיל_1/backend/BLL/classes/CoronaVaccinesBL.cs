using AutoMapper;
using BL.interfaces;
using DAL.interfaces;
using DAL.models;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.classes
{
    public class CoronaVaccinesBL: ICoronaVaccinesBL
    {
        ICoronaVaccinesDAL coronaVaccinesDAL;
        IMapper map;

        public CoronaVaccinesBL(ICoronaVaccinesDAL coronaVaccinesDAL)
        {
            this.coronaVaccinesDAL = coronaVaccinesDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Map>();
            });
            map = config.CreateMapper();
        }

        public List<CoronaVaccinesDTO> GetAll()
        {
            return map.Map<List<CoronaVaccines>, List<CoronaVaccinesDTO>>(coronaVaccinesDAL.GetAll());
        }

        public CoronaVaccinesDTO GetById(int id)
        {
            CoronaVaccines v = coronaVaccinesDAL.GetById(id);
            return map.Map<CoronaVaccines, CoronaVaccinesDTO>(v);
        }
    }
}
