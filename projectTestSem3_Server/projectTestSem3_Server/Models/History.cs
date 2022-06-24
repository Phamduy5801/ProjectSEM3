using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectTestSem3_Server.Models
{
    public class History
    {
        public int Id { get; set; }
        public int Id_bloodProvider { get; set; }
        public int Id_guest { get; set; }
        public int Id_mobiLink { get; set; }
        public string Content { get; set; }
        public ICollection<BloodProvider> bloodProviders { get; set; }
        public ICollection<Guest> guests { get; set; }
        public ICollection<MoibiLink> moibiLinks { get; set; }
    }
}
