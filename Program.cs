using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("cars.csv");
            var manufacturers = ProcessManufacturers("car.csv");
            var query = from car in cars 
                orderby car.City descending, car.Model 
                select car;
            var query2 =
                from car in cars
                where car.Make == "BMW" && car.Year == 2016
                orderby car.City descending, car.Model
                select car;
            var query3 = from car in cars
                join m in manufacturers on car.Model equals m.Make
                select new {m.Make, car.Model, car.City};
            foreach (var car in query.Take(10))
            {
                Console.WriteLine(car.Make + " " + car.Model);
            }

        }

        private static List<Car> ProcessFile(string carsCsv)
        {
            return 
                File.ReadAllLines(carsCsv)
                    .Skip(1)
                    .Where(line => line.Length > 1)
                    .Select(Car.ParseFromCsv)
                    .ToList();
        }
        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query =
                File.ReadAllLines(path)
                    .Where(l => l.Length > 1)
                    .Select(l =>
                    {
                        var columns = l.Split(',');
                        return new Manufacturer
                        {
                            Make = columns[0],
                            Country = columns[1],
                            Year = int.Parse(columns[2])
                        };
                    });
            return query.ToList();
        }
    }
}