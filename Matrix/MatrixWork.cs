using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Matrix
{
    public static class MatrixWork
    {
        /// <summary>
        /// Возвращает минорную матрицу n-1 порядка по первой строке и заданному столбцу
        /// </summary>
        /// <param name="array">Исходная матрица</param>
        /// <param name="row">текущий(исключаемый) столбец</param>
        /// <param name="n">Порядкок исходной матрицы</param>
        /// <returns>minor - минорная матрица тип SqMatrix</returns>
        public static SqMatrix GetMinor(SqMatrix array, int row)
        {
            int n = array.N;
            if (n > 2)
            {
                SqMatrix minor = new SqMatrix(n - 1);

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

                    } while (j < n);
                    ++s; r = 0;
                }
                //minor.Print();
                return minor;
            }
            else
            {
                Console.WriteLine("Для данной матрицы не может быть вычислена минорная - порядок меньше 3");
                return array;
            }

        }
        /// <summary>
        /// Вычисляет определитель матрицы
        /// </summary>
        /// <param name="array">Объект матрицы типа SqMatrix</param>
        /// <returns>det - определитель матрицы</returns>
        public static int Determinant (SqMatrix array)
        {
            int n = array.N;
            int det = 0;
            if (n<3)
            {
                det = array.Table[0, 0] * array.Table[1, 1] - array.Table[1, 0] * array.Table[0, 1];
                return det;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    int result = array.Table[0, i] * Determinant(GetMinor(array, i));
                    if (i%2 == 0)
                    {
                        det += result;
                    }
                    else
                    {
                        det -= result;
                    }
                                   
                }
                return det;
            }

        }

        /// <summary>
        /// Принимает список матриц и вычисляет сумму определителей aсинхронно
        /// </summary>
        /// <param name="lstMatrix">Список обектов матриц SqMatrix</param>
        public static async void DeterminantAsync(List<SqMatrix> lstMatrix)
        {
            var result = new List<long>();
            foreach (var matrix in lstMatrix)
            {
                var task = Task<int>.Run(() => Determinant(matrix));
                result.Add(await task);
            }
            
            Console.WriteLine($"Сумма определителей(асинхронно) = {result.Sum()}");
        }
        /// <summary>
        /// Принимает список матриц и вычисляет сумму определителей синхронно
        /// </summary>
        /// <param name="lstMatrix">Список обектов матриц SqMatrix</param>
        public static  void DeterminantSync(List<SqMatrix> lstMatrix)
        {
            var result = new List<long>();
            foreach (var matrix in lstMatrix)
            {
                result.Add(Determinant(matrix));
                
            }

            Console.WriteLine($"Сумма определителей(синхронно)  = {result.Sum()}");
        }
        /// <summary>
        /// Метод генерирует матрицу заданного порядка(n) и записывает в файл порядок и саму матрицу
        /// </summary>
        /// <param name="path">Путь к файлу для записи</param>
        public static void Generate(string path)
        {
            Thread.Sleep(150);
            Random rnd = new Random(DateTime.Now.Millisecond);

            //!!!!!! ЗДЕСЬ ЗАДАЕМ ПОРЯДОК ГЕРЕРИРУЕМЫХ МАТРИЦ!!!!!!!!!!!
            int n = rnd.Next(9, 11);
            
            int[,] a = new int[n, n];
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(n);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = rnd.Next(-9, 9);
                        
                        //не пишем пробел после последнего числа в строке, дабы не огрести на чтении.
                        if (j==n-1) sw.Write($"{a[i, j]}");
                        else sw.Write($"{a[i,j]} ");

                        //Console.Write(string.Format("{0,4}",a[i,j]));
                    }
                    //Console.WriteLine();
                    sw.Write("\n");
                }
            };
            
        }
        /// <summary>
        /// Читает возвращает прочитанную из файла матрицу в виде объекта SqMatrix
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Объект SqMatrix</returns>
        public static SqMatrix ReadFromFile(string path)
        {

            using (StreamReader ts = new StreamReader(path))
            {
                
                int i = 0;
                int n = Convert.ToInt32(ts.ReadLine());
                SqMatrix matrix = new SqMatrix(n);
                while (ts.Peek() >= 0)
                {
                    var str = ts.ReadLine().Split(' ');
                    int j = 0;
                    foreach (var item in str)
                    {
                        matrix.Table[i, j++] = Convert.ToInt32(item);
                    }
                    ++i;
                }
                return matrix;
            };
            
        }
    }
}
