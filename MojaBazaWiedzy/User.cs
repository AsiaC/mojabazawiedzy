using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBazaWiedzy
{
    class User
    {
        public Group UserGroup { get; set; }
    }
    [System.FlagsAttribute]
    public enum Group
    {
        Users=1,
        Supervisiors=2,
        Managers=4,
        Administrators=8
    }
}
