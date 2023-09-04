using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr1x
{
    public class FillArray
    {
        public static int[] ArrayKeyboard(int size)
        {
            int[] arr = new int[size];
            Console.WriteLine("\nВведите элементы массива: \n");
            for (int i = 0; i < size;)
            {
                Console.Write("Элемент [" + i + "] : ");
                var check = int.TryParse(Console.ReadLine(), out arr[i]);
                if (!check)
                {
                    Console.WriteLine("Введён некорректный элемент массива! Попробуйте снова.\n");
                }
                else
                    i++;
            }
            Console.WriteLine();
            return arr;
        }

        public static int[] ArrayRandom(int size)
        {
            Random rnd = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(-100, 100);
            }
            Console.WriteLine("Исходный массив: \n");
            foreach (int q in arr)
            {
                Console.Write(q + " ");
            }
            Console.WriteLine();
            return arr;
        }

        public static void ArrayFile()
        {
            for (; ; )
            {
                Console.WriteLine("\nВведите путь к файлу: \n");
                string path = Console.ReadLine();
                if (WorkWithFiles.IsFilePathOk(path))
                {
                    string[] arr_str = File.ReadAllText(path).
                    Split(new Char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    int size = arr_str.Length;
                    int[] arr = new int[size];
                    int flag = 2;
                    for (int i = 0; i < size;)
                    {
                        var check = int.TryParse(arr_str[i], out arr[i]);
                        if (!check)
                        {
                            Console.WriteLine("Данные в файле некоректны!  Попробуйте снова.\n");
                            flag = 1;
                            break;
                        }
                        else
                        {
                            i++;
                            flag = 0;
                        }
                    }

                    if (flag == 2)
                    {
                        Console.WriteLine("\nФайл пустой! Выберите другой. \n");
                    }
                    if (flag == 0)
                    {
                        Console.WriteLine("\nИсходный массив: \n");
                        foreach (int q in arr)
                        {
                            Console.Write(q + " ");
                        }
                        Console.WriteLine();
                        WorkWithFiles.SaveData(arr);
                        arr = WorkOnArray.get_max(arr);
                        if (arr[0] > 0)
                            WorkWithFiles.SaveOutput(arr);
                        break;

                    }

                }
            }
        }
    }

    public class Checks
    {

        public enum OptionsSubMenu
        {
            Yes = 1,
            No
        }

        public static bool SubMenu(string decision)
        {
            if (decision != "1" && decision != "2")
            {
                Console.WriteLine("\nНекорректный пункт меню! Попробуйте снова\n");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool Menu(string menu)
        {
            if (menu != "1" && menu != "2" && menu != "3" && menu != "4")
            {
                Console.WriteLine("\nНекорректный пункт меню! Попробуйте снова\n");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsSizeOk(string arr_size)
        {
            int size;
            var check = int.TryParse(arr_size, out size);
            if ((size <= 0) || (check == false))
            {
                Console.WriteLine("\nНекорректный размер массива! Попробуйте снова\n");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}