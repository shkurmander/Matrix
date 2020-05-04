using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SqMatrix
    {
        /// <summary>
        /// Массив-матрица
        /// </summary>
        private int[,] Table  {get; set; }

        /// <summary>
        /// Размерность матрицы-массива
        /// </summary>
        private int N { get; set; }


        public SqMatrix(int n)
        {
            this.N = n;
            Table = new int[N,N];
            //Table = new int[4, 4] { { 1, 2, 4, 3 }, { -6, 5, -13, 8 }, { 9, 5, 8, 1 },{ -1, 4, -3, 2 } };
        }

        public int GetN()
        {
            return N;
        }
        public void Print()
        {
            for (int i = 0; i < N; i++)
            {
                
                for (int j = 0; j < N; j++)
                {
                    Console.Write(String.Format("{0,4}", Table[i,j]));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void Input()
        {
            
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Введите элементы {i+1} строки матрицы через пробел") ;
                var str = Console.ReadLine().Split(' ');
                int j = 0;
                foreach (var item in str)
                {
                    this.Table[i, j++] = Convert.ToInt32(item);
                }                                
                
            }
        }

        public SqMatrix GetMinor(SqMatrix array,int row, int n)
        {
            SqMatrix minor = new SqMatrix(n-1);
            

                int s = 0; int r = 0;
                for (int i = 1; i < n; i++)
                {
                    
                    int j = 0;
                    do
                    {
                    if (j != row)
                    {
                        minor.Table[s, r] = array.Table[i, j];
                        ++j; ++r;
                    }
                    else
                    {
                        ++j;
                        continue;
                    }

                    } while (j<n);
                    ++s; r = 0;
                }
                minor.Print();
                return minor;

        
        }

    }
}
