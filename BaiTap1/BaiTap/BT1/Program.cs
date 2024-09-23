// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public abstract double CalculateSalary();
    }

    public class FactoryWorker : Employee
    {
        public double BasicSalary { get; set; }
        public int ProductCount { get; set; }

        public override double CalculateSalary()
        {
            return BasicSalary + ProductCount * 5000;
        }
    }

    public class OfficeWorker : Employee
    {
        public int WorkingDays { get; set; }

        public override double CalculateSalary()
        {
            return WorkingDays * 100000;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            while (true)
            {
                Console.WriteLine("1. Thêm nhân viên sản xuất");
                Console.WriteLine("2. Thêm nhân viên văn phòng");
                Console.WriteLine("3. Hiển thị thông tin nhân viên");
                Console.WriteLine("4. Thoát");
                Console.Write("Chọn một tùy chọn: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddFactoryWorker(employees);
                        break;
                    case 2:
                        AddOfficeWorker(employees);
                        break;
                    case 3:
                        DisplayEmployees(employees);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
                        break;
                }
            }
        }

        static void AddFactoryWorker(List<Employee> employees)
        {
            FactoryWorker worker = new FactoryWorker();
            Console.Write("Nhập tên: ");
            worker.Name = Console.ReadLine();
            Console.Write("Nhập ngày sinh (yyyy-MM-dd): ");
            worker.BirthDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Nhập lương cơ bản: ");
            worker.BasicSalary = double.Parse(Console.ReadLine());
            Console.Write("Nhập số sản phẩm: ");
            worker.ProductCount = int.Parse(Console.ReadLine());

            employees.Add(worker);
            Console.WriteLine("Đã thêm nhân viên sản xuất.");
        }

        static void AddOfficeWorker(List<Employee> employees)
        {
            OfficeWorker worker = new OfficeWorker();
            Console.Write("Nhập tên: ");
            worker.Name = Console.ReadLine();
            Console.Write("Nhập ngày sinh (yyyy-MM-dd): ");
            worker.BirthDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Nhập số ngày làm việc: ");
            worker.WorkingDays = int.Parse(Console.ReadLine());

            employees.Add(worker);
            Console.WriteLine("Đã thêm nhân viên văn phòng.");
        }

        static void DisplayEmployees(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"Tên: {employee.Name}");
                Console.WriteLine($"Ngày sinh: {employee.BirthDate.ToShortDateString()}");
                Console.WriteLine($"Lương: {employee.CalculateSalary():C}");
                Console.WriteLine();
            }
        }
    }
}