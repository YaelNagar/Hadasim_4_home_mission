using System;
using System.Collections.Generic;

namespace DAL.models
{
    public partial class CoronaVaccines
    {
        public CoronaVaccines()
        {
            VaccineToMember = new HashSet<VaccineToMember>();
        }

        public int Id { get; set; }
        public string TypeVaccine { get; set; }
        public string ManufacturerVaccine { get; set; }

        public virtual ICollection<VaccineToMember> VaccineToMember { get; set; }
    }
}
