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
            List<SqMatrix> lst = new List<SqMatrix>();                              //Создаем список матриц
                        
            /*for (int i = 1; i < 10; i++)                                          //генерируем матрицы
            {
                MatrixWork.Generate($@"c:\Matrix\matrix{i}.txt");
            }*/
   
            for (int i = 1; i < 10; i++)                                             //Читаем матрицы из файлов в список
            {
               lst.Add(MatrixWork.ReadFromFile($@"c:\Matrix\matrix{i}.txt"));
            }

            //Расчет суммы определителей синхронно            
            Console.WriteLine("Начинаем синхронные вычисления\n");
            MatrixWork.DeterminantSync(lst);
            Console.WriteLine("\nЭто сообщение появилось только когда завершились синхронные вычисления\n");


            //Расчет суммы определителей АСИНХРОННО
            Console.WriteLine("Начинаем Асинхронные вычисления\n");
            MatrixWork.DeterminantAsync(lst);
            Console.WriteLine("\nЭто сообщение появилось пока выполняются Асинхронные вычисления\n");

            Console.ReadKey();
        }
       
    }
}
