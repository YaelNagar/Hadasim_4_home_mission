using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HMOMembersDTO
    {
        public int Id { get; set; }
        public string Identity { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Telephone { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? ProfileImage { get; set; }
        public List<CoronaPatientsDTO> CoronaPatients { get; set; }
        public List<VaccineToMemberDTO> VaccineToMember { get; set; }
    }
}
