using FitneyApp.BL.Controller;
using FitneyApp.BL.Model;
using System;
using FitneyApp.CMD.Languages;
using System.Globalization;
using System.Resources;

namespace FitneyApp.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("FitneyApp.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Welcome"), culture);

            Console.Write(resourceManager.GetString("EnterName"), culture);
            var name = Console.ReadLine();

            



            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Ввведите ваш пол: ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime("дата рождения");
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);

            }

            while (true)
            {
                Console.WriteLine(userController.CurrentUser);

                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("Е - ввести приём пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.Finish);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.Write($"\t{item.Activity} с {item.Start.ToShortTimeString()} до {item.End.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;

                }
                Console.ReadLine();
            }

        }

        private static (DateTime Begin, DateTime Finish, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Введите название упражнения: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("Расход энергии в минуту");

            var begin = ParseDateTime("Начало упражнения");
            var finish = ParseDateTime("Конец упражнения");
            var activity = new Activity(name, energy);
            return (begin, finish, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();
            var calories = ParseDouble("калорийность");
            var proteins = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbohydrates = ParseDouble("углеводы");


            var weight = ParseDouble("вес порции");
            var product = new Food(food, calories, proteins, fats, carbohydrates);

            return (Food: product, Weight: weight);


        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine($"Введите {value} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}");

                }
            }
        }
    }
}
