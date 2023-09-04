using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr1x
{
    class Menu
    {
        private enum options
        {
            input_Keyboard = 1,
            input_From_File,
            input_random,
            go_out
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Голова Елена, 474\n" +
                "Данная программа принимает массив чисел размером N" +
                "и находит количество\nотрицательных чисел," +
                " стоящих до максимального положительного числа.");
            Console.WriteLine();
            for (; ; )
            {
                Console.WriteLine("Выберите пункт меню:\n" +
                    "1.Ввести массив с клавиатуры\n" +
                    "2.Ввести массив из файла\n" +
                    "3.Заполнить массив случайными числами\n" +
                    "4.Выйти из программы\n");
                string menu_str = Console.ReadLine();
                if (Checks.Menu(menu_str))
                {
                    var menu = int.Parse(menu_str);
                    int[] arr;
                    var save = new WorkWithFiles();
                    var math_arr = new WorkOnArray();
                    var fill_array = new FillArray();
                    string size_str;
                    switch (menu)
                    {
                        case (int)options.input_Keyboard:
                            while (true)
                            {
                                Console.WriteLine("\n Введите размер массива: \n");
                                size_str = Console.ReadLine();
                                if (Checks.IsSizeOk(size_str))
                                {
                                    int size = int.Parse(size_str);
                                    arr = FillArray.ArrayKeyboard(size);
                                    WorkWithFiles.SaveData(arr);
                                    arr = WorkOnArray.get_max(arr);
                                    if (arr[0] > 0)
                                        WorkWithFiles.SaveOutput(arr);
                                    break;
                                }
                            }
                            break;
                        case (int)options.input_From_File:
                            FillArray.ArrayFile();
                            break;
                        case (int)options.input_random:
                            while (true)
                            {
                                Console.WriteLine("\n Введите размер массива: \n");
                                size_str = Console.ReadLine();
                                if (Checks.IsSizeOk(size_str))
                                {
                                    int size = int.Parse(size_str);
                                    arr = FillArray.ArrayRandom(size);
                                    WorkWithFiles.SaveData(arr);
                                    arr = WorkOnArray.get_max(arr);
                                    if (arr[0] > 0)
                                        WorkWithFiles.SaveOutput(arr);
                                    break;
                                }
                            }
                            break;
                        case (int)options.go_out:
                            return;
                    }
                }
            }
        }
    }
}