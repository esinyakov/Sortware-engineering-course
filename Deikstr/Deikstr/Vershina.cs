using System;
using System.Collections.Generic;
using System.Text;

namespace Deikstr
{
    class Vershina
    {
        char name;
        public char Name => name;
        public Vershina(char a)
        {
            name = a;
        }

        List<(char, char, int)> spisok_reber = new List<(char, char, int)>();
        public List<(char, char, int)> Spisok_reber => spisok_reber;
        public void DobavRebro((char, char, int) a)
        {
            spisok_reber.Add(a);
        }
        

    }
}
