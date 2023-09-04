using System;
using System.Linq;

namespace lr1x
{
    public class WorkOnArray
    {
        public static int[] get_max(int[] arr)
        {
            int[] result = new int[2];
            int maxValue = arr.Max<int>();
            int count = 0;
            if (maxValue > 0)
            {
                foreach (int d in arr)
                {
                    if (d < 0)
                        count++;
                    if (d == maxValue)
                        break;
                }
                Console.WriteLine("\nКоличество отрицательных чисел, стоящих перед"  +
                    "максимальным положительным элементом: {0}" +
                    "\nМаксимальный элемент в массиве : {1}\n", count, maxValue);
                result[0] = count;
                result[1] = maxValue;
                return result;
            }
            else
            {
                Console.WriteLine("\nМаксимальный элемент массива не" +
                    "является положительным!\n");
                return result;
            }

        }
    }
}