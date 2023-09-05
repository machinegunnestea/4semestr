using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Collection<Patient> collectionPatients = new Collection<Patient>();
            ReadingInformationFromFiles(collectionPatients);
            OutputInformation(collectionPatients);
            InputDataNewPatient(collectionPatients);
            OutputInformation(collectionPatients);
            SelectingSort(collectionPatients);

            Console.WriteLine("List of patients with pneumonia: ");
            OutputInformationInList(collectionPatients.Search(CriterionUpTo20YearsWithCodeDiagnosis));


            var numberPatientsAfterSixty = collectionPatients.Where(x => x.Age() > 60).Count();
            Console.WriteLine($"Amount of patients older than 60: {numberPatientsAfterSixty}");
            var averageDeadlineOnDiagnosis = from patient in collectionPatients // источник данных с переменной диапазона
                                             group patient by patient.Diagnosis into g //получение последовательности групп по ключу
                                             select new//преобразования исходных данных в последовательности новых типов
                                             {
                                                 Diag = g.Key, //Distinct: удаляет дублирующиеся элементы из коллекции
                                                 AverageDeadline = g.Average(patient=>patient.LengthOfTreatment)
                                             };

            foreach (var group in averageDeadlineOnDiagnosis)
            {
                Console.WriteLine($"Average length of hospital stay with a diagnosis {group.Diag}: {group.AverageDeadline} days.");

            }
            Console.ReadKey();
        }


        private static void ReadingInformationFromFiles(Collection<Patient> collectionPatients)// try/catch при вызове
        {
            try
            {
                StreamReader reader = new StreamReader("patients.txt");
                string line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    string[] words = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length == 5 && Convert.ToInt32(words[1]) > 1900 && Convert.ToInt32(words[1]) < 2021 && Regex.IsMatch(words[2], @"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"))
                    {
                        collectionPatients.Patients.Push(new Patient { LastName = words[0], YearOfBirth = Convert.ToInt32(words[1]), DateOfAdmission = Convert.ToDateTime(words[2]), LengthOfTreatment = Convert.ToInt32(words[3]), Diagnosis = (Diseases)Convert.ToInt32(words[4]) });
                    }
                    else
                    {
                        throw new Exception("The data in the file is invalid.");
                    }

                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return;
            }
        }
        private static void InputDataNewPatient(Collection<Patient> collectionPatients)
        {
            Console.WriteLine("Enter new patient details");
            Console.Write("Enter the patient's last name: ");
            string inputLastName = Console.ReadLine();
            Console.Write("Enter patient's year of birth: ");
            string input = Console.ReadLine();
            int inputYearOfBirth;
            while (!Int32.TryParse(input, out inputYearOfBirth) || inputYearOfBirth < 1900 || inputYearOfBirth > 2021)
            {
                Console.Write("Wrong input! Enter patient's year of birth:");
                input = Console.ReadLine();
            }
            Console.Write("Enter the patient's admission date(For example: 30/12/2020): ");
            input = Console.ReadLine();
            while (!Regex.IsMatch(input, @"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"))
            {
                Console.Write("Wrong input! Enter the patient's admission date:");
                input = Console.ReadLine();
            }
            DateTime inputDateOfAdmission = Convert.ToDateTime(input);
            Console.Write("Enter the duration of treatment in days:");
            input = Console.ReadLine();
            int inputLengthOfTreatment;
            while (!Int32.TryParse(input, out inputLengthOfTreatment) || inputLengthOfTreatment <= 0)
            {
                Console.Write("Wrong input! Enter the duration of treatment in days: ");
            }
            Console.Write("Enter disease code: ");
            Console.Write("\n Flu = 12 \n Angina = 32, \n Pneumonia = 145,\n Gastritis = 98,\n Bronchitis = 67,\n Hypertension = 34,\n Covid = 777\n");
            int numberDiagnosis;
            input = Console.ReadLine();
            while (!Int32.TryParse(input, out numberDiagnosis) || !System.Enum.IsDefined(typeof(Diseases), numberDiagnosis))
            {
                Console.Write("Wrong input! Enter disease code: ");
                input = Console.ReadLine();
            }
            Diseases inputDiagnosis = (Diseases)numberDiagnosis;
            collectionPatients.Patients.Push(new Patient { LastName = inputLastName, DateOfAdmission = inputDateOfAdmission, YearOfBirth = inputYearOfBirth, Diagnosis = inputDiagnosis, LengthOfTreatment = inputLengthOfTreatment });
        }
        private static void SelectingSort(Collection<Patient> collection)
        {
            Console.WriteLine("Select sort type:\n1 - sort by age\n2 - sort by staying");
            string input = Console.ReadLine();
            int select;
            while (!Int32.TryParse(input, out select) || select < 1 || select > 2)
            {
                Console.Write("Wrong input! Select sort type:\n1 - sort by age\n2 - sort by staying");
                input = Console.ReadLine();
            }
            if (select == 1)
            {
                OutputInformationInList(collection.OrderByDescending(x => x.Age()).ToList());
            }
            if (select == 2)
            {
                List<Patient> SortedPatients = collection.ToList();
                SortedPatients.Sort();
                OutputInformationInList(SortedPatients);
            }
        }
        private static void OutputInformationInList<T>(List<T> list) where T : struct
        {
            Table table = new Table();
            table.HeaderTable();
            table.TableLinesList(list);
            table.BottomTable();
        }
        private static void OutputInformation<T>(Collection<T> collection) where T : struct,IComparable<T>
        {
            Table table = new Table();
            table.HeaderTable();
            table.TableLines(collection);
            table.BottomTable();
        }
        private static bool CriterionUpTo20YearsWithCodeDiagnosis(Patient item) => (item.Age() <= 20 && (int)item.Diagnosis == 145);
    }
}
