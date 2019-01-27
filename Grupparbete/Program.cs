using System;
using System.Collections.Generic;
using System.Linq;

namespace Grupparbete
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] people =
            {
                new Person("Fritz Kovacs", 32, 1),
                new Person("Mimi Franz", 25, 2),
                new Person("Hanna Leiss", 50, 3),
                new Person("Susanne Jukitsch", 70, 1),
                new Person("Susanne Birger", 44, 2)
            };

            WorkPlace[] workplaces =
            {
                new WorkPlace("ICA", 1),
                new WorkPlace("Willys", 2),
                new WorkPlace("Hemköp", 3),
                new WorkPlace("Tempo", 4),
            };

            Console.WriteLine("3a) Personer över 30:");
            var peopleQuery1 = people
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Age);
            peopleQuery1.Print();

            Console.WriteLine("\n5) Personer över 30:");
            List<Person> peopleOverThirty = new List<Person>();
            foreach (var person in people)
            {
                if (person.Age > 30)
                    peopleOverThirty.Add(person);
            }
            peopleOverThirty.SortGenericArray((a, b) => a.Age < b.Age);
            peopleOverThirty.SortGenericArray((a, b) => String.Compare(a.Name, b.Name, true) < 0);
            peopleOverThirty.Print();

            Console.WriteLine("\n3b) Antal person under 30:");
            var peopleQuery2 = people
                .Count(p => p.Age < 30);
            Console.WriteLine(peopleQuery2);

            Console.WriteLine("\n3c) Snittålder:");
            var peopleQuery3 = people.
                Average(p => p.Age);
            Console.WriteLine(peopleQuery3);

            Console.WriteLine("\n3d) Första personen som heter Mimi Franz:");
            var peopleQuery4 = people
                .FirstOrDefault(p => p.Name == "Mimi Franz");
            Console.WriteLine(peopleQuery4);

            Console.WriteLine("\n3e) Alla personer och deras arbetsplatser:");
            var peopleQuery5 = people.
                Join(workplaces, p => p.WorkPlaceID, w => w.WorkPlaceID, (p, w) => new
                { p.Name, w.CompanyName });
            peopleQuery5.Print(p => $"{p.Name}: {p.CompanyName}");

            Console.WriteLine("\n3f) Arbetsplatser och antal anställda:");
            var peopleQuery6 = workplaces.
                GroupJoin(people, w => w.WorkPlaceID, p => p.WorkPlaceID, (w, employees) => new
                { w.CompanyName, EmployeeCount = employees.Count() });
            peopleQuery6.Print(p => $"{p.CompanyName}: {p.EmployeeCount}");

            Console.WriteLine("\n3g) Grupperade anställda");
            var peopleQuery7 = workplaces.
                GroupJoin(people, w => w.WorkPlaceID, p => p.WorkPlaceID, (w, employees) => new
                { w.CompanyName, Employees = employees});

            peopleQuery7.Print(p => $"{p.CompanyName}: \n{String.Join(' ', p.Employees)}");
        }
    }
}
