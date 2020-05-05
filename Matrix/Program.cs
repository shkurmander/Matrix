using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            
            
            Stopwatch stw = new Stopwatch();                                         //инициализируем замер времени выполнения
            stw.Start();


            for (int i = 1; i < 10; i++)                                              //генерируем матрицы
            {
                MatrixWork.Generate($@"c:\Matrix\matrix{i}.txt");
            }
            List<SqMatrix> lst = new List<SqMatrix>();

            for (int i = 1; i < 10; i++)                                             //Читаем матрицы из файлов в список
            {
               lst.Add(MatrixWork.ReadFromFile($@"c:\Matrix\matrix{i}.txt"));
            }
            
            foreach (var item in lst)                                                 //Вычисляем определитель без распараллеливания
            {
                
            }
            
            foreach (var item in lst)                                                
            {
                //item.Print();
                Console.WriteLine($"Детерминант = {MatrixWork.Determinant(item)}");         //Вычисления без распараллеливания

                MatrixWork.DeterminantAsync(item);                                          //Запуск асинхронных вычислений
            }

            Console.WriteLine("Все матрицы обработаны");

            ///Вычисляем и выводим время выполнения программы
            stw.Stop();
            TimeSpan ts = stw.Elapsed;
            string eltime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine($"Работа выполнена за {eltime}");


            Console.ReadKey();
        }
        
    }
}
