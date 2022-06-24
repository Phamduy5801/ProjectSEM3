using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectTestSem3_Server.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public History history { get; set; }

    }
}
