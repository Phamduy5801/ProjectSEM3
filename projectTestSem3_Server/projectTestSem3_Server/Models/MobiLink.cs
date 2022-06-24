using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectTestSem3_Server.Models
{
    public class MoibiLink
    {
        public int Id { get; set; }
        public int Id_guest { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public History history { get; set; }
    }
}
