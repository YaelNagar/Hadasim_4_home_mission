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
    public class HMOMembersBL: IHMOMembersBL
    {
        IHMOMembersDAL hmoMembersDAL;
        IMapper map;

        public HMOMembersBL(IHMOMembersDAL hmoMembersDAL)
        {
            this.hmoMembersDAL = hmoMembersDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Map>();
            });
            map = config.CreateMapper();
        }

        public List<HMOMembersDTO> GetAll()
        {
            return map.Map<List<Hmomembers>, List<HMOMembersDTO>>(hmoMembersDAL.GetAll());
        }

        public HMOMembersDTO GetById(int id)
        {
            Hmomembers m = hmoMembersDAL.GetById(id);
            return map.Map<Hmomembers, HMOMembersDTO>(m);
        }

        public int Add(HMOMembersDTO hmoMember)
        {
            Hmomembers m = map.Map<HMOMembersDTO, Hmomembers>(hmoMember);
            if (CheckMember(m))
                return hmoMembersDAL.Add(m);
            return -1;
        }

        public bool CheckMember(Hmomembers m)
        {
            if (true)//validations
                return true;
            return false;
        }

        public bool Update(HMOMembersDTO m)
        {
            Hmomembers member = map.Map<HMOMembersDTO, Hmomembers>(m);
            if (CheckMember(member))
                return hmoMembersDAL.Update(member);
            return false;
        }

        public bool Delete(int id)
        {
            return hmoMembersDAL.Delete(id);
        }
    }
}
