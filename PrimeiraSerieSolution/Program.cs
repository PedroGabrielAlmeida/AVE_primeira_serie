using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiraSerieSolution
{
    class Program
    {
        static void Main(string[] args)
        {

            List<IArrayOperation> lista = XLoader.Load("AddValue");
            if (lista.Count > 0)
            {
                Console.WriteLine("Lista tem #{0} elementos", lista.Count);
            }
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }
    }
}
