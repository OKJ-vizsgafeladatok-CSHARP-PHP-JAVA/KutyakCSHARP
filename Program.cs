using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KutyakGYAK
{
    class Program
    {
        public static List<Kutyanevek> kutyanevek = beolvasKutyanevek();
        public static List<KutyaFajtak> kutyafajtak = beolvasKutyafajtak();
        public static List<Kutyak> kutyak = beolvasKutyak();
        public static List<Kutyanevek> beolvasKutyanevek()
        {
            List<Kutyanevek> lista = new List<Kutyanevek>();
            FileStream fs = new FileStream("kutyanevek.csv",FileMode.Open);
            using (StreamReader sr=new StreamReader(fs,Encoding.UTF8))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var split = sr.ReadLine().Split(';');
                    var o = new Kutyanevek(Convert.ToInt32(split[0]),split[1]);
                    lista.Add(o);
                }
            }
            fs.Close();
            
            return lista;
        }

        public static List<KutyaFajtak> beolvasKutyafajtak()
        {
            List<KutyaFajtak> lista = new List<KutyaFajtak>();
            FileStream fs = new FileStream("kutyafajtak.csv", FileMode.Open);
            using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var split = sr.ReadLine().Split(';');
                    var o = new KutyaFajtak(Convert.ToInt32(split[0]), split[1],split[2]);
                    lista.Add(o);
                }
            }
            fs.Close();
            return lista;
        }
        public static List<Kutyak> beolvasKutyak()
        {
            List<Kutyak> lista = new List<Kutyak>();
            FileStream fs = new FileStream("kutyak.csv", FileMode.Open);
            using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var split = sr.ReadLine().Split(';');
                    var kutyafajtaID = Convert.ToInt32(split[1]);
                    var fajta = kutyafajtak.SingleOrDefault(
                        x=>x.kutyaFajtaId==kutyafajtaID)
                        .fajtanev;
                    var kutyanevID = Convert.ToInt32(split[2]);
                    var nev = kutyanevek.SingleOrDefault(
                        x=>x.kutyaNevId==kutyanevID)
                        .kutyaNev;
                    var o = new Kutyak(
                        Convert.ToInt32(split[0]),
                        fajta,
                        nev,
                        Convert.ToInt32(split[3]),
                        Convert.ToDateTime(split[4]));
                    lista.Add(o);
                }
            }
            fs.Close();
            return lista;
        }

        static void Main(string[] args)
        {
            #region 3. feladat
            Console.WriteLine("3. feladat: Kutyanevek száma: "+kutyanevek.Count);
            #endregion

            #region 6. feladat
            var atlag = Math.Round(kutyak.Average(x=>x.eletkor),2);
            Console.WriteLine("6. feladat: Kutyák átlag életkora: "+atlag);
            #endregion

            #region 7. feladat
            var leg = kutyak.Max(x=>x.eletkor);
            var legK = kutyak.SingleOrDefault(x=>x.eletkor==leg);
            Console.WriteLine("7. feladat: Legidősebb kutya neve és fajtája: "+legK.nev+", "+legK.fajta);
            #endregion

            #region 8. feladat
            var date = new DateTime(2018,01,10);
            var fajtaCsoportMa = kutyak.Where(x => x.utolsoEll == date).GroupBy(x=>x.fajta).ToList();
            fajtaCsoportMa.ForEach(x=>Console.WriteLine("\t"+x.Key+": "+x.Count()+" kutya"));
            #endregion

            #region 9. feladat
            var legtobben = kutyak.GroupBy(x=>x.utolsoEll).OrderByDescending(x=>x.Count()).First();
            Console.WriteLine("9. feladat: Legjobban leterhelt nap: "+legtobben.Key.ToString("yyyy.MM.dd.")+": "+legtobben.Count());
            #endregion

            #region 10. feladat
            FileStream fs = new FileStream("Névstatisztika.txt",FileMode.Create);
            var NevCsop = kutyak.GroupBy(x => x.nev).OrderByDescending(x=>x.Count()).ToList();
            using (StreamWriter sw=new StreamWriter(fs,Encoding.UTF8))
            {
                NevCsop.ForEach(x =>
                    sw.WriteLine(x.Key+";"+x.Count())
                ) ;
            }
            Console.WriteLine("10. feladat: névstatisztika.txt");
            #endregion

            Console.ReadKey();
        }
    }
}
