using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projectTestSem3_Server.Models;

namespace projectTestSem3_Server.Data
{
    public class projectTestSem3_ServerContext : IdentityDbContext<IdentityUser>
    {
        public projectTestSem3_ServerContext (DbContextOptions<projectTestSem3_ServerContext> options)
            : base(options)
        {
        }


        public DbSet<projectTestSem3_Server.Models.BloodProvider> BloodProvider { get; set; }

        public DbSet<projectTestSem3_Server.Models.Guest> Guest { get; set; }

        public DbSet<projectTestSem3_Server.Models.MoibiLink> MoibiLink { get; set; }

        public DbSet<projectTestSem3_Server.Models.History> History { get; set; }
    }
}
