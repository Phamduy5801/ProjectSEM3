using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectTestSem3_Server
{
    public interface IAuth
    {
        string Authentication(string username, string password);
    }
}
