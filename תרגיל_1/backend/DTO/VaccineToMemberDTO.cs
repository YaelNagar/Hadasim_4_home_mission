using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VaccineToMemberDTO
    {
        public int IdMember { get; set; }
        public int IdVaccine { get; set; }
        public CoronaVaccinesDTO CoronaVaccine { get; set; }
    }
}
