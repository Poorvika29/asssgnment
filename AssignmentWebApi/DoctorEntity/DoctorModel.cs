using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorEntity
{
    public class DoctorModel
    {
        public int Id { get; set; }
        public string DocName { get; set; }
        public int WorkEx { get; set; }
        public string Location { get; set; }
        public int Fee { get; set; }
        public string Category { get; set; }
    }
}
