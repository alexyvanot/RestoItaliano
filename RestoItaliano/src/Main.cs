using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoItaliano.src.model;

namespace RestoItaliano.src
{
    public class main
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Terminal terminal = Terminal.GetInstance();
            terminal.InitSampleDatas();
            terminal.Start();
        }

    }
}
