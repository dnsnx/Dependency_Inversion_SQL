using Dependency_Inversion_SQL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Inversion_SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            ICar car = Factory.CreateCar();
            Console.WriteLine($"My dream car is an { car.GetCarName() }");
            Console.ReadLine();
        }
    }
}
