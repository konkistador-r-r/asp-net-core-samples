using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* The syntax required to implement an overloaded operator is
 * 
 * public static <return type> operator <symbol>(params)
 * { ... }
 * The operator is static, which is the only way it can and should be declared because an operator belongs to the type and not a particular instance.
 * 
 * C# enforces certain rules when you overload operators. 
 * 
 * One rule is that you must implement the operator overload in the type that will use it. 
 * This is sensible because it makes the type self-contained.
 * 
 * Another rule is that you must implement matching operators. For example, 
 * if you overload ==, you must also implement !=. The same goes for <= and >=.
 * 
 * When you implement an operator, its compound operator works also. For example, 
 * since the + operator for the Matrix type was implemented, you can also use the += operator on Matrix types.
 */

namespace Lessons
{
    class OverloadingOperators
    {
        internal class Matrix
        {
            public const int DimSize = 3;
            private double[,] m_matrix = new double[DimSize, DimSize];

            // allow callers to initialize
            public double this[int x, int y]
            {
                get { return m_matrix[x, y]; }
                set { m_matrix[x, y] = value; }
            }

            // let user add matrices
            public static Matrix operator +(Matrix mat1, Matrix mat2)
            {
                Matrix newMatrix = new Matrix();

                for (int x = 0; x < DimSize; x++)
                    for (int y = 0; y < DimSize; y++)
                        newMatrix[x, y] = mat1[x, y] + mat2[x, y];

                return newMatrix;
            }
        }

        public static Random m_rand = new Random();

        // initialize matrix with random values
        public static void InitMatrix(Matrix mat)
        {
            for (int x = 0; x < Matrix.DimSize; x++)
                for (int y = 0; y < Matrix.DimSize; y++)
                    mat[x, y] = m_rand.NextDouble();
        }

        // print matrix to console
        public static void PrintMatrix(Matrix mat)
        {
            Console.WriteLine();
            for (int x = 0; x < Matrix.DimSize; x++)
            {
                Console.Write("[ ");
                for (int y = 0; y < Matrix.DimSize; y++)
                {
                    // format the output
                    Console.Write("{0:#.000000}", mat[x, y]); //?

                    if (y < Matrix.DimSize -1) //((y + 1 % 2) < 3)
                        Console.Write(", ");
                }
                Console.WriteLine(" ]");
            }
            Console.WriteLine();
        }

        public static void MainMethod()
        {
            Matrix mat1 = new Matrix();
            Matrix mat2 = new Matrix();

            // init matrices with random values
            InitMatrix(mat1);
            InitMatrix(mat2);

            // print out matrices
            Console.WriteLine("Matrix 1: ");
            PrintMatrix(mat1);

            Console.WriteLine("Matrix 2: ");
            PrintMatrix(mat2);

            // perform operation and print out results
            Matrix mat3 = mat1 + mat2;

            Console.WriteLine();
            Console.WriteLine("Matrix 1 + Matrix 2 = ");
            PrintMatrix(mat3);

            Console.ReadLine();
        }
    }
}
