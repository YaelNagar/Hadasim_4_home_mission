using System;
using System.Collections.Generic;

namespace DAL.models
{
    public partial class Hmomembers
    {
        public Hmomembers()
        {
            CoronaPatients = new HashSet<CoronaPatients>();
            VaccineToMember = new HashSet<VaccineToMember>();
        }

        public int Id { get; set; }
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Telephone { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ProfileImage { get; set; }

        public virtual ICollection<CoronaPatients> CoronaPatients { get; set; }
        public virtual ICollection<VaccineToMember> VaccineToMember { get; set; }
    }
}
