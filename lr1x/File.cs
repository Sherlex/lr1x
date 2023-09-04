using System;
using System.IO;
using System.Linq;

namespace lr1x
{
    public class WorkWithFiles
    {

        public static void SaveData(int[] arr)
        {
            while (true)
            {
                Console.WriteLine("\n\n Cохранить массив?\n\n1 - Да\n2 - Нет\n");
                string save_str = Console.ReadLine();
                int flag = 0;
                if (Checks.SubMenu(save_str))
                {
                    var save = int.Parse(save_str);
                    switch (save)
                    {
                        case (int)Checks.OptionsSubMenu.Yes:
                            while (true)
                            {
                                Console.WriteLine("Введите путь для сохранения: \n");
                                string path = Console.ReadLine();
                                if (!File.Exists(path))
                                {
                                    if (IsSavingPathOk(path))
                                    {
                                        File.Create(path).Close();
                                        SaveArray(arr, path);
                                        break;
                                    }
                                }
                                else
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Файл существует! Хотите перезаписать? \n1 - Да\n2 - Нет\n");
                                        string rewrite_str = Console.ReadLine();
                                        if (Checks.SubMenu(rewrite_str))
                                        {
                                            var rewrite = int.Parse(rewrite_str);
                                            switch (rewrite)
                                            {
                                                case (int)Checks.OptionsSubMenu.Yes:
                                                    flag = 1;
                                                    SaveArray(arr, path);
                                                    break;
                                                case (int)Checks.OptionsSubMenu.No:
                                                    break;
                                            }
                                            break;
                                        }
                                    }
                                    if (flag == 1)
                                        break;
                                }
                            }
                            break;

                        case (int)Checks.OptionsSubMenu.No:
                            break;
                    }
                    break;
                }
            }
        }


        public static void SaveOutput(int[] arr)
        {
            while (true)
            {
                Console.WriteLine("\n Cохранить результат?\n\n1 - Да\n2 - Нет\n");
                string save_str = Console.ReadLine();
                int flag = 0;
                if (Checks.SubMenu(save_str))
                {
                    var save = int.Parse(save_str);
                    switch (save)
                    {
                        case (int)Checks.OptionsSubMenu.Yes:
                            while (true)
                            {
                                Console.WriteLine("Введите путь для сохранения: \n");
                                string path = Console.ReadLine();
                                if (!File.Exists(path))
                                {
                                    if (IsSavingPathOk(path))
                                    {
                                        File.Create(path).Close();
                                        SaveResults(arr, path);
                                        break;
                                    }
                                }
                                else
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Файл существует! Хотите перезаписать? \n1 - Да\n2 - Нет\n");
                                        string rewrite_str = Console.ReadLine();
                                        if (Checks.SubMenu(rewrite_str))
                                        {
                                            var rewrite = int.Parse(rewrite_str);
                                            switch (rewrite)
                                            {
                                                case (int)Checks.OptionsSubMenu.Yes:
                                                    SaveResults(arr, path);
                                                    flag = 1;
                                                    break;
                                                case (int)Checks.OptionsSubMenu.No:
                                                    break;
                                            }
                                            break;
                                        }
                                    }
                                    if (flag == 1)
                                        break;
                                }
                            }
                            break;

                        case (int)Checks.OptionsSubMenu.No:
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            }
        }

        private static void SaveResults(int[] arr, string path)
        {
            StreamWriter file = new StreamWriter(path);
            file.WriteLine("Количество отрицательных чисел : {0}" +
                             "\nМаксимальный элемент в массиве : {1}", arr[0], arr[1]);
            file.Close();
            file.Dispose();
            Console.WriteLine("Файл успешно сохранён! ");
            Console.ReadKey();
        }

        private static void SaveArray(int[] arr, string path)
        {
            StreamWriter file = new StreamWriter(path);
            foreach (int i in arr)
            {
                file.WriteLine(i);
            }
            file.Close();
            file.Dispose();
            Console.WriteLine("Файл успешно сохранён! ");
        }


        public static bool IsFilePathOk(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Некорректный путь! Попробуйте снова.\n");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsSavingPathOk(string path)
        {
            try
            {
                File.Create(path).Close();
                File.Delete(path);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " Попробуйте снова.");
                return false;
            }
        }
    }
}