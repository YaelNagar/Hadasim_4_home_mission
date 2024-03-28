using AutoMapper;
using DAL.classes;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DTO
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<CoronaVaccines, CoronaVaccinesDTO>();
            CreateMap<CoronaVaccinesDTO, CoronaVaccines>();
            CreateMap<CoronaPatients, CoronaPatientsDTO>();
            CreateMap<CoronaPatientsDTO, CoronaPatients>();
            CreateMap<VaccineToMember, VaccineToMemberDTO>()
                .ForMember(x => x.CoronaVaccine, map => map.MapFrom(y => new CoronaVaccinesDAL().GetById(y.IdVaccine)));
            CreateMap<VaccineToMemberDTO, VaccineToMember>();
            CreateMap<Hmomembers, HMOMembersDTO>()
                .ForMember(x => x.CoronaPatients, map => map.MapFrom(y => new CoronaPatientsDAL().GetByIdMember(y.Id)))
                .ForMember(x => x.VaccineToMember, map => map.MapFrom(y => new VaccineToMemberDAL().GetByIdMember(y.Id)));
            CreateMap<HMOMembersDTO, Hmomembers>();
        }
    }
}
