using FitneyApp.BL.Controller;
using FitneyApp.BL.Model;
using System;

namespace FitneyApp.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет");

            Console.WriteLine("Введите ваше имя");
            var name = Console.ReadLine();

            Console.WriteLine("Введите ваш пол");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            var birthDate = DateTime.Parse(Console.ReadLine()); //TODO: переписать в TryParse

            Console.WriteLine("Введите ваш вес");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите ваш рост");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();


        }
    }
}
