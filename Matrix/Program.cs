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
            /*Console.WriteLine("Введите порядок матрицы:");
            var n = Int32.Parse(Console.ReadLine());
            SqMatrix a = new SqMatrix(n);
            //a.Input();*/
            for (int i = 1; i < 10; i++)
            {
                MatrixWork.Generate($@"c:\Matrix\matrix{i}.txt");
            }
            List<SqMatrix> lst = new List<SqMatrix>();

            for (int i = 1; i < 10; i++)
            {
               lst.Add(MatrixWork.ReadFromFile($@"c:\Matrix\matrix{i}.txt"));
            }

            foreach (var item in lst)
            {
                item.Print();
                Console.WriteLine($"Детерминант = {MatrixWork.Determinant(item)}");
            }


            //a.FileInput(@"c:\Matrix\Matrix1.txt");
            /*
            Console.WriteLine($"\nИсходная матрица:");
            a.Print();        
            Console.WriteLine($"Детерминант = {MatrixWork.Determinant(a)}");*/
            Console.WriteLine("Все матрицы обработаны");
            Console.ReadKey();
        }
        
    }
}
