using System;
using System.Collections.Generic;

namespace DAL.models
{
    public partial class CoronaPatients
    {
        public int Id { get; set; }
        public int IdMember { get; set; }
        public DateTime CoronaBeginDate { get; set; }
        public DateTime? CoronaEndDate { get; set; }

        public virtual Hmomembers IdMemberNavigation { get; set; }
    }
}
