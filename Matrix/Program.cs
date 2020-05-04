using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите порядок матрицы:");
            var n = Int32.Parse(Console.ReadLine());
            SqMatrix a = new SqMatrix(n);
            a.Input();
            Console.WriteLine($"\nИсходная матрица:");
            a.Print();        
            Console.WriteLine($"Детерминант = {MatrixWork.Determinant(a)}");
            Console.ReadKey();
        }
        
    }
}
