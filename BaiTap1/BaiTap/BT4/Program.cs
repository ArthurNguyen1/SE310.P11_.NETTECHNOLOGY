// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace ShapeManagement
{
    public class Ellipse
    {
        public double SemiMajorAxis { get; set; }
        public double SemiMinorAxis { get; set; }

        public virtual double Area()
        {
            return Math.PI * SemiMajorAxis * SemiMinorAxis;
        }

        public virtual void Display()
        {
            Console.WriteLine($"Hình Ellipse - Bán trục lớn: {SemiMajorAxis}, Bán trục nhỏ: {SemiMinorAxis}");
            Console.WriteLine($"Diện tích: {Area():F2}");
        }
    }

    public class Circle : Ellipse
    {
        public double Radius
        {
            get { return SemiMajorAxis; }
            set { SemiMajorAxis = SemiMinorAxis = value; }
        }

        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public override void Display()
        {
            Console.WriteLine($"Hình Tròn - Bán kính: {Radius}");
            Console.WriteLine($"Diện tích: {Area():F2}");
        }
    }

    class Program
    {
        static List<Ellipse> shapes = new List<Ellipse>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nChọn một tùy chọn:");
                Console.WriteLine("1. Thêm hình Ellipse");
                Console.WriteLine("2. Thêm hình Tròn");
                Console.WriteLine("3. Hiển thị danh sách hình");
                Console.WriteLine("4. Thoát");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddEllipse();
                        break;
                    case 2:
                        AddCircle();
                        break;
                    case 3:
                        DisplayShapes();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
                        break;
                }
            }
        }

        static void AddEllipse()
        {
            Ellipse ellipse = new Ellipse();
            Console.Write("Nhập bán trục lớn: ");
            ellipse.SemiMajorAxis = double.Parse(Console.ReadLine());
            Console.Write("Nhập bán trục nhỏ: ");
            ellipse.SemiMinorAxis = double.Parse(Console.ReadLine());
            shapes.Add(ellipse);
            Console.WriteLine("Đã thêm hình Ellipse.");
        }

        static void AddCircle()
        {
            Circle circle = new Circle();
            Console.Write("Nhập bán kính: ");
            circle.Radius = double.Parse(Console.ReadLine());
            shapes.Add(circle);
            Console.WriteLine("Đã thêm hình Tròn.");
        }

        static void DisplayShapes()
        {
            if (shapes.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            for (int i = 0; i < shapes.Count; i++)
            {
                Console.WriteLine($"\nHình thứ {i + 1}:");
                shapes[i].Display();
            }
        }
    }
}