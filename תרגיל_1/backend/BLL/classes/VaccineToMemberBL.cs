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
    public class VaccineToMemberBL : IVaccineToMemberBL
    {
        IVaccineToMemberDAL vaccineToMemberDAL;
        IMapper map;

        public VaccineToMemberBL(IVaccineToMemberDAL vaccineToMemberDAL)
        {
            this.vaccineToMemberDAL = vaccineToMemberDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Map>();
            });
            map = config.CreateMapper();
        }

        public List<VaccineToMemberDTO> GetByIdMember(int idMember)
        {
            List<VaccineToMember> v = vaccineToMemberDAL.GetByIdMember(idMember);
            return map.Map<List<VaccineToMember>, List<VaccineToMemberDTO>>(v);
            //VaccineToMemberDTO vDTO = map.Map<VaccineToMember, VaccineToMemberDTO>(v);
            //vDTO.CoronaVaccine = new CoronaVaccinesDAL().GetById(vDTO.IdVaccine)
        }

        public int Add(VaccineToMemberDTO vaccineToMember)
        {
            VaccineToMember v = map.Map<VaccineToMemberDTO, VaccineToMember>(vaccineToMember);
            return vaccineToMemberDAL.Add(v);
        }

        public int CountMemberVaccine()
        {
            return vaccineToMemberDAL.GetAll().GroupBy(v => v.IdMember).Count();
        }
    }
}
