using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace linq
{
    internal class Zad1
    {
        private string f, i, o;
       private int age, ves;
        public string F { get; set; }
        public string I { get; set; }
        public string O { get; set; }
        public int Age { get; set; }
        public int Ves { get; set; }
        public Zad1(string f,string i,string o,int age,int ves)
        {
            this.f = f;
            this.i = i;
            this.o = o;
            this.age = age;
            this.ves = ves;
        }
        public string Info()
        {
            return $"{f} {i} {o} {age} {ves}";
        }
    }
}
