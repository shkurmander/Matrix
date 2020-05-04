using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public static class MatrixWork
    {
        /// <summary>
        /// Возвращает  матрицу n-1 порядка по первой строке и заданному столбцу
        /// </summary>
        /// <param name="array">Исходная матрица</param>
        /// <param name="row">текущий(исключаемый) столбец</param>
        /// <param name="n">Порядкок исходной матрицы</param>
        /// <returns></returns>
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
                minor.Print();
                return minor;
            }
            else
            {
                Console.WriteLine("Для данной матрицы не может быть вычислена минорная - порядок меньше 3");
                return array;
            }

        }

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
                    if (i%2 == 0)
                    {
                        det += array.Table[0,i]*Determinant(GetMinor(array, i));
                    }
                    else
                    {
                        det -= array.Table[0, i]*Determinant(GetMinor(array, i));
                    }
                                   
                }
                return det;
            }

        }

    }
}
