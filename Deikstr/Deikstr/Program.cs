using System;
using System.Collections.Generic;
using System.Linq;

namespace Deikstr
{
    class Program
    {
        static void Main(string[] args)
        {
            int kol_vershin = 6;


            Dictionary<char, int> dlina_krat_puti_iz_starta = new Dictionary<char, int>(kol_vershin);
            Dictionary<char, bool> proiden = new Dictionary<char, bool>(kol_vershin);
            Dictionary<char, char> predki = new Dictionary<char, char>();

            for (int i = 0; i < kol_vershin; i++)
            {
                dlina_krat_puti_iz_starta.Add((char)('a' + i), 1000);
                proiden.Add((char)('a' + i), false);
            }
            dlina_krat_puti_iz_starta['a'] = 0;

            for (int i = 1; i < kol_vershin; i++)
            {
                predki.Add((char)('a' + i), 'a');
            }

            Vershina A = new Vershina('a');
            A.DobavRebro(('a', 'b', 1));
            A.DobavRebro(('a', 'c', 10));
            A.DobavRebro(('a', 'f', 7));
            Vershina B = new Vershina('b');
            B.DobavRebro(('b', 'c', 6));
            B.DobavRebro(('b', 'd', 1));
            Vershina C = new Vershina('c');
            C.DobavRebro(('c', 'd', 9));
            C.DobavRebro(('c', 'f', 8));
            Vershina D = new Vershina('d');
            D.DobavRebro(('d', 'e', 1));
            Vershina E = new Vershina('e');
            E.DobavRebro(('e', 'f', 2));
            Vershina F = new Vershina('f');

            List<Vershina> Spisok_ver = new List<Vershina>() { A, B, C, D, E, F };
            for (int i = 0; i < kol_vershin; i++)
            {
                Dictionary<char, int> tmp_dlina_krat_puti_iz_starta = new Dictionary<char, int>(dlina_krat_puti_iz_starta);
                foreach (var proi in proiden)
                {
                    if (proi.Value == true)
                    {
                        tmp_dlina_krat_puti_iz_starta.Remove(proi.Key);
                    }
                }

                var min = tmp_dlina_krat_puti_iz_starta.Values.Min();
                var temp = tmp_dlina_krat_puti_iz_starta.Select(p => p).Where(p => p.Value == min).First();
                proiden[temp.Key] = true;

                foreach (var vershina in Spisok_ver)
                {
                    if (vershina.Name == temp.Key)
                    {
                        for(char j = 'a'; j<= dlina_krat_puti_iz_starta.Last().Key; j++)
                        {
                            foreach(var rebro in vershina.Spisok_reber)
                            {
                                if ((rebro.Item2 == j) && (rebro.Item3 + dlina_krat_puti_iz_starta[vershina.Name] < dlina_krat_puti_iz_starta[j]))
                                {
                                    dlina_krat_puti_iz_starta[j] = rebro.Item3 + dlina_krat_puti_iz_starta[vershina.Name];
                                    predki[j] = vershina.Name;
                                }
                            }
                        }
                    }
                }
            }

            foreach (var d in dlina_krat_puti_iz_starta)
            {
                Console.WriteLine($"Kratchaishee rast do {d.Key} ravno {d.Value}");
            
            }
            Console.WriteLine($"Put do f");
            void printPredok(char a)
            {
                try { Console.WriteLine(predki[a]); }
                catch {  return; }
                printPredok(predki[a]);
            }

            printPredok('f');
        }
    }
}
