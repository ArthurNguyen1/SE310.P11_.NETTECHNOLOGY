// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace FarmAnimalManagement
{
    public abstract class Animal
    {
        public abstract string MakeSound();
        public abstract int GiveBirth();
        public abstract double ProduceMilk();
    }

    public class Cow : Animal
    {
        public override string MakeSound()
        {
            return "Moo";
        }

        public override int GiveBirth()
        {
            return new Random().Next(1, 3); // Bò sinh 1-2 con
        }

        public override double ProduceMilk()
        {
            return new Random().Next(0, 21); // 0-20 lít sữa
        }
    }

    public class Sheep : Animal
    {
        public override string MakeSound()
        {
            return "Baa";
        }

        public override int GiveBirth()
        {
            return new Random().Next(1, 4); // Cừu sinh 1-3 con
        }

        public override double ProduceMilk()
        {
            return new Random().Next(0, 6); // 0-5 lít sữa
        }
    }

    public class Goat : Animal
    {
        public override string MakeSound()
        {
            return "Meh";
        }

        public override int GiveBirth()
        {
            return new Random().Next(1, 3); // Dê sinh 1-2 con
        }

        public override double ProduceMilk()
        {
            return new Random().Next(0, 11); // 0-10 lít sữa
        }
    }

    public class Farm
    {
        private List<Animal> animals = new List<Animal>();

        public void AddAnimals(string type, int count)
        {
            for (int i = 0; i < count; i++)
            {
                switch (type.ToLower())
                {
                    case "cow":
                        animals.Add(new Cow());
                        break;
                    case "sheep":
                        animals.Add(new Sheep());
                        break;
                    case "goat":
                        animals.Add(new Goat());
                        break;
                }
            }
        }

        public void SimulateSound()
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.MakeSound());
            }
        }

        public void SimulateBreedingAndMilking()
        {
            int cowCount = 0, sheepCount = 0, goatCount = 0;
            double totalMilk = 0;

            foreach (var animal in animals)
            {
                int newborns = animal.GiveBirth();
                double milk = animal.ProduceMilk();

                if (animal is Cow)
                {
                    cowCount += newborns;
                    for (int i = 0; i < newborns; i++) animals.Add(new Cow());
                }
                else if (animal is Sheep)
                {
                    sheepCount += newborns;
                    for (int i = 0; i < newborns; i++) animals.Add(new Sheep());
                }
                else if (animal is Goat)
                {
                    goatCount += newborns;
                    for (int i = 0; i < newborns; i++) animals.Add(new Goat());
                }

                totalMilk += milk;
            }

            Console.WriteLine($"Số bò mới sinh: {cowCount}");
            Console.WriteLine($"Số cừu mới sinh: {sheepCount}");
            Console.WriteLine($"Số dê mới sinh: {goatCount}");
            Console.WriteLine($"Tổng số lít sữa: {totalMilk:F2}");
        }

        public void DisplayStatistics()
        {
            int cowCount = 0, sheepCount = 0, goatCount = 0;

            foreach (var animal in animals)
            {
                if (animal is Cow) cowCount++;
                else if (animal is Sheep) sheepCount++;
                else if (animal is Goat) goatCount++;
            }

            Console.WriteLine($"Tổng số bò: {cowCount}");
            Console.WriteLine($"Tổng số cừu: {sheepCount}");
            Console.WriteLine($"Tổng số dê: {goatCount}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Farm farm = new Farm();

            Console.Write("Nhập số lượng bò ban đầu: ");
            int cowCount = int.Parse(Console.ReadLine());
            farm.AddAnimals("cow", cowCount);

            Console.Write("Nhập số lượng cừu ban đầu: ");
            int sheepCount = int.Parse(Console.ReadLine());
            farm.AddAnimals("sheep", sheepCount);

            Console.Write("Nhập số lượng dê ban đầu: ");
            int goatCount = int.Parse(Console.ReadLine());
            farm.AddAnimals("goat", goatCount);

            Console.WriteLine("\nTiếng kêu của các gia súc khi đói:");
            farm.SimulateSound();

            Console.WriteLine("\nSau một lứa sinh và một lược cho sữa:");
            farm.SimulateBreedingAndMilking();

            Console.WriteLine("\nThống kê cuối cùng:");
            farm.DisplayStatistics();
        }
    }
}