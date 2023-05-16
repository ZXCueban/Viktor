using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Application
{
    class MainClass
    {
        public enum Type { П, С, А, Неизвестен }

        struct Kadr
        {
            public string pname;
            public Type type;
            public int year;
            public double salary;

            public string toString()
            {
                return String.Format("{0};{1};{2};{3}\n",
                        this.pname,
                        this.type.ToString(),
                        this.year,
                        this.salary);
            }
            public void DisplayInfo()
            {
                Console.WriteLine($"{pname,-20} {type,-21} {year,-20} {salary,-20}");
            }

        }
        struct Log
        {
            public string pname;
            public DateTime time;
            public string operation;

            public void DisplayLog()
            {
                Console.WriteLine($"{time,-20} {operation,-20} {pname,-20}");
            }
        }

        public static void Main(string[] args)
        {
            var main = new MainClass();


            Kadr Ivanov;
            Ivanov.pname = "Иванов И.И.";
            Ivanov.salary = 4170.50;
            Ivanov.year = 1998;
            Ivanov.type = Type.П;

            Kadr Petrenko;
            Petrenko.pname = "Петренко П.П.";
            Petrenko.salary = 790.10;
            Petrenko.year = 1997;
            Petrenko.type = Type.С;

            Kadr Sidorevich;
            Sidorevich.pname = "Сидоревич С.С.";
            Sidorevich.salary = 2200.00;
            Sidorevich.year = 1999;
            Sidorevich.type = Type.А;

            var Table = new List<Kadr>();
            Table.Add(Ivanov);
            Table.Add(Petrenko);
            Table.Add(Sidorevich);

            var Log = new List<Log>();
            DateTime time_1 = DateTime.Now;
            DateTime time_2 = DateTime.Now;
            TimeSpan timeInterval_1 = time_2 - time_1;

            string Menu = "\n1 – Просмотр таблицы \n2 – Добавить запись \n3 – Удалить запись \n4 – Обновить запись \n5 – Поиск записей \n6 – Просмотреть лог \n7 – Выход \n8 - Бэкап";
            bool optionError = true;

            do
            {
                Console.WriteLine(Menu);
                int Option = Convert.ToInt32(Console.ReadLine());
                switch (Option)
                {
                    case 1: 
                        for (int i = 0; i < Table.Count; i++)
                        {
                            Table[i].DisplayInfo();
                        }
                        break;

                    case 2: 
                        {
                            Console.WriteLine("Введите ФИО: ");
                            string pname = Console.ReadLine();

                            Console.WriteLine("Введите должность: (П, С, А)");
                            var type = Type.Неизвестен;
                            string choiceType = Console.ReadLine();

                            Console.WriteLine("Введите год рождения: ");
                            int year = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Введите оклад: ");
                            double salary = double.Parse(Console.ReadLine());


                            if (choiceType == "П")
                            {
                                type = Type.П;
                            }
                            else if (choiceType == "С")
                            {
                                type = Type.С;
                            }
                            else if (choiceType == "А")
                            {
                                type = Type.А;
                            }

                            Kadr newKadr;
                            newKadr.pname = pname;
                            newKadr.salary = salary;
                            newKadr.year = year;
                            newKadr.type = type;
                            Table.Add(newKadr);

                            Log newLog;
                            newLog.pname = pname;
                            newLog.time = DateTime.Now;
                            newLog.operation = "Запись добавлена.";
                            Log.Add(newLog);

                            time_1 = DateTime.Now;
                            TimeSpan timeInterval_2 = time_1 - time_2;
                            if (timeInterval_1 < timeInterval_2)
                            {
                                timeInterval_1 = timeInterval_2;
                            }
                            time_2 = newLog.time;
                        }
                        break;

                    case 3: 
                        {
                            Console.Write("Введите номер записи: ");


                            int choiceNumberDelete = Convert.ToInt32(Console.ReadLine());
                            if (choiceNumberDelete > 0 && choiceNumberDelete < Table.Count)
                            {
                                Log newDelete;
                                newDelete.pname = Table[choiceNumberDelete - 1].pname;
                                newDelete.time = DateTime.Now;
                                newDelete.operation = "Запись удалена!";
                                Log.Add(newDelete);
                                Table.RemoveAt(choiceNumberDelete - 1);

                                time_1 = DateTime.Now;
                                TimeSpan timeInterval_2 = time_1 - time_2;
                                if (timeInterval_1 < timeInterval_2)
                                {
                                    timeInterval_1 = timeInterval_2;
                                }
                                time_2 = newDelete.time;

                            }
                        }
                        break;

                    case 4: 
                        {
                            Console.Write("Введите номер записи: ");

                            int choiceNumberChange = Convert.ToInt32(Console.ReadLine());
                            if (choiceNumberChange > 0 && choiceNumberChange < Table.Count)
                            {
                                string oldpname = Table[choiceNumberChange - 1].pname;
                                Console.WriteLine("Введите новое ФИО: ");
                                string pname = Console.ReadLine();
                                if (pname == String.Empty)
                                {
                                    pname = oldpname;
                                }

                                double oldsalary = Table[choiceNumberChange - 1].salary;
                                Console.WriteLine("Введите новый оклад: ");
                                double salary = double.Parse(Console.ReadLine());


                                int oldYear = Table[choiceNumberChange - 1].year;
                                Console.WriteLine("Введите новый год рождения: ");
                                int year = Convert.ToInt32(Console.ReadLine());

                                var oldType = Table[choiceNumberChange - 1].type;
                                Console.WriteLine("Введите новую должность: (П, С, А)");
                                var type = Type.Неизвестен;
                                string choiceType = Console.ReadLine();
                                if (choiceType == "П")
                                {
                                    type = Type.П;
                                }
                                else if (choiceType == "С")
                                {
                                    type = Type.С;
                                }
                                else if (choiceType == "А")
                                {
                                    type = Type.А;

                                }
                            }
                        }
                        break;

                    case 5: 
                        {
                            Console.WriteLine("Введите должность (П, С, А): ");

                            Char choiceNumberSearch = Convert.ToChar(Console.ReadLine());
                            if (choiceNumberSearch == 'П')
                            {
                                var records = Table.FindAll(i => i.type == Type.П);
                                foreach (var record in records)
                                {
                                    record.DisplayInfo();
                                }
                            }
                            else if (choiceNumberSearch == 'С')
                            {
                                var records = Table.FindAll(i => i.type == Type.С);
                                foreach (var record in records)
                                {
                                    record.DisplayInfo();
                                }
                            }
                            else if (choiceNumberSearch == 'А')
                            {
                                var records = Table.FindAll(i => i.type == Type.А);
                                foreach (var record in records)
                                {
                                    record.DisplayInfo();
                                }
                            }

                        }
                        break;

                    case 6: 
                        {
                            for (int i = 0; i < Log.Count; i++)
                            {
                                Log[i].DisplayLog();
                            }
                            Console.WriteLine();
                            Console.WriteLine(timeInterval_1 + " - Самый долгий период бездействия пользователя");
                        }
                        break;

                    case 7: 
                        {
                            optionError = false;
                            using (StreamWriter writer = new StreamWriter("E:/labtext.dat"))
                            {
                                foreach (Kadr kadr in Table)
                                {
                                    writer.Write(kadr.toString());
                                }
                            }

                            // Сохранение в бинарный файл
                            using (BinaryWriter writer = new BinaryWriter(File.Open("E:/labbinary.dat", FileMode.Create)))
                            {
                                foreach (Kadr kadr in Table)
                                {
                                    writer.Write(kadr.pname);
                                    writer.Write(kadr.type.ToString());
                                    writer.Write(kadr.year);
                                    writer.Write(kadr.salary);
                                }
                            }
                            Console.WriteLine("Таблица сохранена на диск.");
                            break;
                        }
                        break;


                    case 8: 
                        {
                            string directoryName = "E:/Lab6_Temp";
                            if (!Directory.Exists(directoryName))
                            {
                                Directory.CreateDirectory(directoryName);
                            }

                            string sourceFile = "E:/labtext.dat";
                            string destFile = Path.Combine(directoryName, sourceFile);
                            File.Copy(sourceFile, destFile, true);
                            Console.WriteLine($"Файл {sourceFile} скопирован в директорию {directoryName}");

                            string backupFile = "lab_backup.dat";
                            using (FileStream sourceStream = File.Open(sourceFile, FileMode.Open))
                            using (FileStream backupStream = File.Create(Path.Combine(directoryName, backupFile)))
                            {
                                byte[] buffer = new byte[1024];
                                int bytesRead;
                                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    backupStream.Write(buffer, 0, bytesRead);
                                }
                            }
                            Console.WriteLine($"Файл {sourceFile} скопирован в директорию {directoryName} под именем {backupFile}");
                            Console.WriteLine($"Информация о файле {sourceFile}:");
                            Console.WriteLine($"Размер: {new FileInfo(sourceFile).Length} байт");
                            Console.WriteLine($"Время последнего изменения: {new FileInfo(sourceFile).LastWriteTime}");
                            Console.WriteLine($"Время последнего доступа: {new FileInfo(sourceFile).LastAccessTime}");
                            break;
                        }
                        break;


                    default:
                        Console.WriteLine("Введите правильную команду!");
                        optionError = true;
                        break;
                }
            }
            while (optionError);
        }
    }
}