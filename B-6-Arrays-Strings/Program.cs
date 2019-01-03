using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string cutString;

            int[] arrayB6_1 = new int[20];
            int[,] arrayB6_2_2Dimention = new int[3, 4];  
            

            /////////////////////////////////////////////////////
            //  B6-P1 1DReadConsoleMassive
            arrayB6_1 = ArrayGenerator(arrayB6_1);
            ArrayPrint(arrayB6_1);

            /////////////////////////////////////////////////////
            //  B6-P2 2dMassiveMaxInRow
            arrayB6_2_2Dimention = ArrayGenerator(arrayB6_2_2Dimention);
            ArrayPrint(arrayB6_2_2Dimention);

            /////////////////////////////////////////////////////
            //  B6-P3 1dMassiveSort
            ArrayPrint(arrayB6_1);
            arrayB6_1 = MassiveBubbleSort(arrayB6_1);
            //arrayB6_1 = MassiveInsertionSort(arrayB6_1);            
            ArrayPrint(arrayB6_1);


            /////////////////////////////////////////////////////
            //  B6-P4 Pyatnashki
            //Pyatnashki();

            /////////////////////////////////////////////////////
            //  B6-P5 CutString
            Console.WriteLine("Введите строку");
            cutString = Console.ReadLine();
            cutString = cutString.Substring(0, 13).Trim()+"...";
            Console.WriteLine(cutString);

            /////////////////////////////////////////////////////
            //  B6-P5 ReplaseInPoem

            Console.WriteLine("Введите четверостишие разделенное запятыми");
            cutString = Console.ReadLine();
            var poem = cutString.ToLower().Replace("о","а").Replace("л", "ль").Replace("ть","т").Split(',');
            foreach (var item in poem)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////     
        public static int[] MassiveBubbleSort(int[] forSort)
        {
            bool flag=true;
            int swap;
            int cyclenumbers = 0;
            while (flag)
            {
                flag = false;
                for (int i = 1; i < forSort.Length- cyclenumbers; i++)
                {
                    if (forSort[i] < forSort[i - 1])
                    {
                        swap = forSort[i];
                        forSort[i] = forSort[i - 1];
                        forSort[i - 1] = swap;
                        flag = true;
                    }                    
                }
                cyclenumbers++;
            }
            Console.WriteLine($"{cyclenumbers} проходов");
            return forSort;
        }

        public static int[] MassiveInsertionSort(int[] forSort)
        {
            int swap;
            int cyclenumbers = 0;
            for (int i = 1; i < forSort.Length; i++)
            {
                for (int j = i; j >0 ; j--)
                {
                    cyclenumbers++;
                    if (forSort[j]< forSort[j-1])
                    {
                        swap = forSort[j];
                        forSort[j] = forSort[j - 1];
                        forSort[j - 1] = swap;
                    }
                }
            }
            Console.WriteLine($"{cyclenumbers} проходов");
            return forSort;
        }


        public static void ArrayPrint(int[] D1array)
        {
            foreach (var i in D1array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public static void ArrayPrint(int[,] D1array)
        {
            for (int i = 0; i < D1array.GetLength(0); i++)
            {
                int max = 0;
                for (int j = 0; j < D1array.GetLength(1); j++)
                {
                    max = D1array[i, j] > max ? D1array[i, j] : max;
                    Console.Write(D1array[i,j] + " ");
                }
                Console.Write($"  Maximum in row  {max} \n");
            }            
            Console.WriteLine();
        }

        public static int[] ArrayGenerator(int[] D1array)
        {
            Random rnd = new Random();
            for (int i = 0; i < D1array.Length; i++)
            {
                D1array[i] = rnd.Next(-10, 10);
            }
            Console.WriteLine("Массив заполнен!");
            return D1array;
        }

        public static int[,] ArrayGenerator(int[,] D1array)
        {
            Random rnd = new Random();
            for (int i = 0; i < D1array.GetLength(0) ; i++)
            {
                for (int j = 0; j < D1array.GetLength(1); j++)
                {
                    D1array[i,j] = rnd.Next(0, 10);
                }               
            }
            Console.WriteLine("Массив заполнен!");
            return D1array;            
        }

        public static void Pyatnashki()
        {
            var Field = GenerateArray4x4();
            char move;
            int swap;
            int positionI = 3;
            int positionJ = 3;
            int i =3, j= 3;
            while (true)
            {
                positionI = i;
                positionJ = j;

                PrintPyatnashki(Field);
                
                move = Console.ReadKey().KeyChar;                
                
                switch (move)
                {
                    case 'w':
                        i--;
                        break;
                    case 's':
                        i++;
                        break;
                    case 'a':
                        j--;
                        break;
                    case 'd':
                        j++;
                        break;
                    default:
                        continue;
                }
                if ((i<4 && i > -1) && (j < 4 && j > -1) )
                {
                    swap = Field[positionI,positionJ];
                    Field[positionI, positionJ] = Field[i, j];
                    Field[i, j] = swap;
                }
                else
                {
                    i = positionI;
                    j = positionJ;
                }
            }
        }

        public static int[,] GenerateArray4x4()
        {
            int[,] pyatnashkiField = new int[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    pyatnashkiField[i, j] = i*4 + j + 1;
                }
            }
            pyatnashkiField[3, 3] = 0;
            return pyatnashkiField;
        }

        public static void PrintPyatnashki(int[,] pyatnashkiField)
        {
            Console.Clear();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(String.Format("{0,4}", pyatnashkiField[i, j])); 
                }
                Console.WriteLine();
            }
        }

        public static void PoemExample()
        {
            
        }
    }
}
