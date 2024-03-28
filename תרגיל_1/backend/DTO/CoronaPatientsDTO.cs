using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CoronaPatientsDTO
    {
        public int Id { get; set; }
        public int IdMember { get; set; }
        public DateTime CoronaBeginDate { get; set; }
        public DateTime? CoronaEndDate { get; set; }

    }
}
