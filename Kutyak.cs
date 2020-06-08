using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutyakGYAK
{
    class Kutyak
    {
        public int kutyaId { get; set; }
        public string fajta { get; set; }
        public string nev { get; set; }
        public int eletkor { get; set; }
        public DateTime utolsoEll { get; set; }

        public Kutyak(int kutyaId, string fajta, string nev, int eletkor, DateTime utolsoEll)
        {
            this.kutyaId = kutyaId;
            this.fajta = fajta;
            this.nev = nev;
            this.eletkor = eletkor;
            this.utolsoEll = utolsoEll;
        }
    }
}
