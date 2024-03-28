using AutoMapper;
using BL.interfaces;
using DAL.interfaces;
using DAL.models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.classes
{
    public class CoronaPatientsBL : ICoronaPatientsBL
    {
        ICoronaPatientsDAL coronaPatientsDAL;
        IMapper map;

        public CoronaPatientsBL(ICoronaPatientsDAL coronaPatientsDAL)
        {
            this.coronaPatientsDAL = coronaPatientsDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Map>();
            });
            map = config.CreateMapper();
        }

        public List<CoronaPatientsDTO> GetByIdMember(int idMember)
        {
            List<CoronaPatients> p = coronaPatientsDAL.GetByIdMember(idMember);
            return map.Map<List<CoronaPatients>, List<CoronaPatientsDTO>>(p);
        }

        public int Add(CoronaPatientsDTO coronaPatientsDTO)
        {
            CoronaPatients p = map.Map<CoronaPatientsDTO, CoronaPatients>(coronaPatientsDTO);
            return coronaPatientsDAL.Add(p);
        }

        public List<KeyValuePair<int, int>> LastMonthCoronaPatients()
        {
            return coronaPatientsDAL.GetAll()
                .Where(x => x.CoronaBeginDate.Year == DateTime.Now.Year &&
                x.CoronaBeginDate.Month == DateTime.Now.Month-1)
                .GroupBy(x => x.CoronaBeginDate.Day)
                .Select(group => new KeyValuePair<int, int>(group.Key, group.Count()))
                .ToList();
        }
    }
}
