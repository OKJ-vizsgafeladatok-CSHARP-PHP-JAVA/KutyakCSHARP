using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutyakGYAK
{
    class Kutyanevek
    {
        public int kutyaNevId { get; set; }
        public string kutyaNev { get; set; }

        public Kutyanevek(int kutyaNevId, string kutyaNev)
        {
            this.kutyaNevId = kutyaNevId;
            this.kutyaNev = kutyaNev;
        }

    }
}
