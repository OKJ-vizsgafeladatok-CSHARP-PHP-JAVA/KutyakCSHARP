using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutyakGYAK
{
    class KutyaFajtak
    {
        public int kutyaFajtaId { get; set; }
        public string fajtanev { get; set; }
        public string fajtaEredetiNev { get; set; }

        public KutyaFajtak(int kutyaFajtaId, string fajtanev, string fajtaEredetiNev)
        {
            this.kutyaFajtaId = kutyaFajtaId;
            this.fajtanev = fajtanev;
            this.fajtaEredetiNev = fajtaEredetiNev;
        }
    }
}
