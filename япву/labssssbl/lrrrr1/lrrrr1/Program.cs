using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Subscriber[] allSubscribers = ReadingDataFromFileOfSubscribers();
            Journal[] allJournals = ReadingDataFromFileOfJournals();

            Array.Sort(allSubscribers);

            RegistrationSubscribers(allSubscribers, allJournals);

            OutputTableInformation(allSubscribers);

            SelectingJournalToChangeName(allJournals, allSubscribers);

            OutputTableInformation(allSubscribers);

            SelectingJournalToChangePriceSubscription(allJournals, allSubscribers);

            OutputTableInformation(allSubscribers);

            Console.ReadKey();
        }

        private static void OutputTableInformation(Subscriber[] allSubscribers)
        {
            Table table = new Table();
            table.HeaderTable();
            for (int i = 0; i < allSubscribers.Length; i++)
            {
                allSubscribers[i].InformationOutput(i + 1);
            }
            table.BottomTable();
        }
        private static Subscriber[] ReadingDataFromFileOfSubscribers()
        {
            Subscriber[] allSubscribers = new Subscriber[File.ReadLines("subscribers.txt").Count()];
            for (int i = 0; i < allSubscribers.Length; i++)
            {
                allSubscribers[i] = new Subscriber();
            }
            try
            {
                if (allSubscribers.Length == 0)
                {
                    throw new Exception("Файл с данными о подписчиках пуст.");
                }
                StreamReader readerFirstFile = new StreamReader("subscribers.txt");
                string line;
                for (int i = 0; !readerFirstFile.EndOfStream; i++)
                {
                    line = readerFirstFile.ReadLine();
                    string[] data = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    if (data.Length == 3)
                    {
                        allSubscribers[i].LastName = data[0];
                        allSubscribers[i].Address = data[1];
                        string[] namesOfJournalsOfLine = data[2].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        allSubscribers[i].AllCostOfSubscriptions = new Dictionary<string, double>(namesOfJournalsOfLine.Length);/////
                        for (int j = 0; j < namesOfJournalsOfLine.Length; j++)
                        {
                            StreamReader readerSecondFile = new StreamReader("journals.txt");
                            for (int k = 0; !readerSecondFile.EndOfStream; k++)
                            {
                                string[] dataFromSecondFile = readerSecondFile.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                                if (dataFromSecondFile.Length != 2)
                                {
                                    throw new Exception($"Данные о журналах не достоверные. {i + 1} строка.");
                                }
                                if (dataFromSecondFile[0] == namesOfJournalsOfLine[j].Trim())
                                {
                                    allSubscribers[i].AllCostOfSubscriptions.Add(namesOfJournalsOfLine[j].Trim(), Convert.ToDouble(dataFromSecondFile[1]));
                                    break;
                                }
                            }
                            readerSecondFile.Close();
                        }
                    }
                    else
                    {
                        throw new Exception($"Данные о подписчиках в файле не достоверные. {i + 1} строка.");
                    }
                }
                readerFirstFile.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                return null;
            }
            return allSubscribers;
        }
        private static Journal[] ReadingDataFromFileOfJournals()
        {
            Journal[] allJournals = new Journal[File.ReadLines("journals.txt").Count()];
            for (int i = 0; i < allJournals.Length; i++)
            {
                allJournals[i] = new Journal();
            }
            try
            {
                if (allJournals.Length == 0)
                {
                    throw new Exception("Файл с данными о журналах пуст.");
                }
                StreamReader readerSecondFile = new StreamReader("journals.txt");
                string line;
                for (int i = 0; !readerSecondFile.EndOfStream; i++)
                {
                    line = readerSecondFile.ReadLine();
                    string[] data = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    if (data.Length == 2)
                    {
                        allJournals[i].NameOfJournal = data[0];
                        allJournals[i].SubscriptionPrice = Convert.ToDouble(data[1]);
                    }
                    else
                    {
                        throw new Exception($"Данные о журналах в файле не достоверные. {i + 1} строка.");
                    }
                }
                readerSecondFile.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                return null;
            }
            return allJournals;
        }
        private static void RegistrationSubscribers(Subscriber[] allSubscribers, Journal[] allJournals)
        {
            for (int i = 0; i < allJournals.Length; i++)
            {
                for (int j = 0; j < allSubscribers.Length; j++)
                {
                    foreach (KeyValuePair<string, double> costOfSubscriptions in allSubscribers[j].AllCostOfSubscriptions)
                    {
                        if (costOfSubscriptions.Key == allJournals[i].NameOfJournal)
                        {
                            allJournals[i].ObserverRegistration(new ChangeInName(allSubscribers[j].ChangeOfNameJournal));
                            break;
                        }
                    }
                }
            }
        }
        private static void SelectingJournalToChangeName(Journal[] allJournals, Subscriber[] allSubscribers)
        {
            for (int i = 0; i < allJournals.Length; i++)
            {
                Console.WriteLine($"{i + 1}-{allJournals[i].NameOfJournal}");
            }
            int number;
            Console.Write("Введите номер журнала, у которого необходимо изменить название: ");
            string input = Console.ReadLine();
            while (!Int32.TryParse(input, out number) || number > allJournals.Length || number < 1)
            {
                Console.Write("Произошла ошибка. Введите номер журнала, у которого необходимо изменить название: ");
                input = Console.ReadLine();
            }
            allJournals[number - 1].InputName();
        }
        private static void SelectingJournalToChangePriceSubscription(Journal[] allJournals, Subscriber[] allSubscribers)
        {
            for (int i = 0; i < allJournals.Length; i++)
            {
                Console.WriteLine($"{i + 1}-{allJournals[i].NameOfJournal}-{allJournals[i].SubscriptionPrice}");
            }
            int number;
            Console.Write("Введите номер журнала, у которого необходимо изменить стоимость годовой подписки: ");
            string input = Console.ReadLine();
            while (!Int32.TryParse(input, out number) || number > allJournals.Length || number < 1)
            {
                Console.Write("Произошла ошибка. Введите номер журнала, у которого необходимо изменить стоимость годовой подписки: ");
                input = Console.ReadLine();
            }
            for (int i = 0; i < allSubscribers.Length; i++)
            {
                string pattern = @"(.*)ул.Советская(.*)";
                if (!Regex.IsMatch(allSubscribers[i].Address, pattern, RegexOptions.IgnoreCase))
                {
                    foreach (KeyValuePair<string, double> costOfSubscriptions in allSubscribers[i].AllCostOfSubscriptions)
                    {
                        if (costOfSubscriptions.Key == allJournals[number - 1].NameOfJournal)
                        {
                            allJournals[number - 1].PriceChange += allSubscribers[i].ChangeOfPriceJournal;
                            break;
                        }
                    }
                }
            }
            allJournals[number - 1].InputPrice();
        }
    }
}
