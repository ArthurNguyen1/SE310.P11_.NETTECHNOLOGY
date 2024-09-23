// See https://aka.ms/new-console-template for more information
using System;

namespace GeometricShapesManagement
{
    public abstract class Shape
    {
        public abstract double Area();
        public abstract void Input();
        public abstract void Display();
    }

    public class Trapezoid : Shape
    {
        public double TopBase { get; set; }
        public double BottomBase { get; set; }
        public double Height { get; set; }

        public override double Area()
        {
            return 0.5 * (TopBase + BottomBase) * Height;
        }

        public override void Input()
        {
            Console.Write("Nhập độ dài đáy trên: ");
            TopBase = double.Parse(Console.ReadLine());
            Console.Write("Nhập độ dài đáy dưới: ");
            BottomBase = double.Parse(Console.ReadLine());
            Console.Write("Nhập chiều cao: ");
            Height = double.Parse(Console.ReadLine());
        }

        public override void Display()
        {
            Console.WriteLine("Hình thang:");
            Console.WriteLine($"Đáy trên: {TopBase}, Đáy dưới: {BottomBase}, Chiều cao: {Height}");
            Console.WriteLine($"Diện tích: {Area():F2}");
        }
    }

    public class Parallelogram : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public override double Area()
        {
            return Base * Height;
        }

        public override void Input()
        {
            Console.Write("Nhập độ dài cạnh đáy: ");
            Base = double.Parse(Console.ReadLine());
            Console.Write("Nhập chiều cao: ");
            Height = double.Parse(Console.ReadLine());
        }

        public override void Display()
        {
            Console.WriteLine("Hình bình hành:");
            Console.WriteLine($"Cạnh đáy: {Base}, Chiều cao: {Height}");
            Console.WriteLine($"Diện tích: {Area():F2}");
        }
    }

    public class Rectangle : Parallelogram
    {
        public double Width
        {
            get { return Base; }
            set { Base = value; }
        }
        public double Length { get; set; }

        public override double Area()
        {
            return Width * Length;
        }

        public override void Input()
        {
            Console.Write("Nhập chiều rộng: ");
            Width = double.Parse(Console.ReadLine());
            Console.Write("Nhập chiều dài: ");
            Length = double.Parse(Console.ReadLine());
            Height = Length;
        }

        public override void Display()
        {
            Console.WriteLine("Hình chữ nhật:");
            Console.WriteLine($"Chiều rộng: {Width}, Chiều dài: {Length}");
            Console.WriteLine($"Diện tích: {Area():F2}");
        }
    }

    public class Square : Rectangle
    {
        public double Side
        {
            get { return Width; }
            set { Width = Length = value; }
        }

        public override void Input()
        {
            Console.Write("Nhập độ dài cạnh: ");
            Side = double.Parse(Console.ReadLine());
        }

        public override void Display()
        {
            Console.WriteLine("Hình vuông:");
            Console.WriteLine($"Độ dài cạnh: {Side}");
            Console.WriteLine($"Diện tích: {Area():F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shape shape = null;

            Console.WriteLine("Chọn loại hình:");
            Console.WriteLine("1. Hình thang");
            Console.WriteLine("2. Hình bình hành");
            Console.WriteLine("3. Hình chữ nhật");
            Console.WriteLine("4. Hình vuông");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    shape = new Trapezoid();
                    break;
                case 2:
                    shape = new Parallelogram();
                    break;
                case 3:
                    shape = new Rectangle();
                    break;
                case 4:
                    shape = new Square();
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    return;
            }

            shape.Input();
            Console.WriteLine("\nThông tin hình đã nhập:");
            shape.Display();
        }
    }
}