using System;
using System.Collections.Generic;

namespace DAL.models
{
    public partial class VaccineToMember
    {
        public int Id { get; set; }
        public int IdMember { get; set; }
        public int IdVaccine { get; set; }

        public virtual Hmomembers IdMemberNavigation { get; set; }
        public virtual CoronaVaccines IdVaccineNavigation { get; set; }
    }
}
