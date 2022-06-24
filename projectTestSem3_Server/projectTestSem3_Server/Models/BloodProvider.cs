using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projectTestSem3_Server.Models
{
    public class BloodProvider
    {
        public int Id { get; set; }       
        public string Name { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public string Weight { get; set; }
        public DateTime Birth { get; set; }
        public string BloodType { get; set; }
        public string Tel { get; set; }
        public DateTime Time_BloodDnt { get; set; }
        public History history { get; set; }
    }
}
