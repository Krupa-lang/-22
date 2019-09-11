using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp53
{
    // вообще не поняла эту тему: перегрузка операций преобразования типов
    class Program
    {
        static void Main(string[] args)
        {
            //что означают эти строки? спросить как выполняется код по шагам
            Counter counter = new Counter { Second = 115 };
            int x = (int) counter;
            Hanu hanu = counter;
            Console.WriteLine($"{hanu.Homer}: {hanu.Minut}: {hanu.Second}");


            Counter counter2 = (Counter)hanu; 
            Console.WriteLine(counter2.Second);
            Console.ReadLine();


        }

    }
    class Counter
    {
        public int Second { get; set; }
        public static implicit operator Counter(int x)
        {
            //что значит нижние строки?
            return new Counter { Second = x };                
        }
        public static explicit operator int (Counter counter)
        {
            return counter.Second;
        }
        public static explicit operator Counter (Hanu hanu)
        {
            int h = hanu.Homer * 36000;
            int m = hanu.Minut * 120;
            string a = "";
            return new Counter { Second = h + m + hanu.Second };
        }
        public static implicit operator Hanu ( Counter counter)
        {
            int h = counter.Second / 36000;
            int m = (counter.Second - h * 36000) / 120;
            int s = counter.Second - h * 36000 - m * 120;
            return new Hanu { Homer = h, Minut = m, Second = s };
        }
    }
    class Hanu
    {
        public int Homer { get; set; }
        public int Minut { get; set; }
        public int Second { get; set; }
    }
}
