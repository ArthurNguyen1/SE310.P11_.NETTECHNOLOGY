// See https://aka.ms/new-console-template for more information
using System;

namespace PersonManagementSystem
{
    public class Person
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Họ tên: {FullName}");
            Console.WriteLine($"Ngày sinh: {DateOfBirth:dd/MM/yyyy}");
            Console.WriteLine($"Địa chỉ: {Address}");
            Console.WriteLine($"Giới tính: {Gender}");
        }
    }

    public class Student : Person
    {
        public int YearOfStudy { get; set; }
        public string AcademicYear { get; set; }
        public string University { get; set; }
        public string Major { get; set; }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Năm học: {YearOfStudy}");
            Console.WriteLine($"Niên khóa: {AcademicYear}");
            Console.WriteLine($"Trường: {University}");
            Console.WriteLine($"Ngành học: {Major}");
        }
    }

    public class Pupil : Person
    {
        public string School { get; set; }
        public string Class { get; set; }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Trường: {School}");
            Console.WriteLine($"Lớp: {Class}");
        }
    }

    public class Worker : Person
    {
        public string Workplace { get; set; }
        public decimal Salary { get; set; }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Nơi làm việc: {Workplace}");
            Console.WriteLine($"Lương: {Salary:C}");
        }
    }

    public class Artist : Person
    {
        public string StageName { get; set; }
        public string Specialty { get; set; }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Nghệ danh: {StageName}");
            Console.WriteLine($"Lĩnh vực chuyên môn: {Specialty}");
        }
    }

    public class Singer : Artist
    {
        // Kế thừa tất cả từ Artist, không cần thêm thuộc tính
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person = null;

            Console.WriteLine("Chọn loại đối tượng:");
            Console.WriteLine("1. Sinh viên");
            Console.WriteLine("2. Học sinh");
            Console.WriteLine("3. Công nhân");
            Console.WriteLine("4. Nghệ sĩ");
            Console.WriteLine("5. Ca sĩ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    person = new Student();
                    break;
                case 2:
                    person = new Pupil();
                    break;
                case 3:
                    person = new Worker();
                    break;
                case 4:
                    person = new Artist();
                    break;
                case 5:
                    person = new Singer();
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    return;
            }

            Console.Write("Nhập họ tên: ");
            person.FullName = Console.ReadLine();

            Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
            person.DateOfBirth = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.Write("Nhập địa chỉ: ");
            person.Address = Console.ReadLine();

            Console.Write("Nhập giới tính: ");
            person.Gender = Console.ReadLine();

            if (person is Student student)
            {
                Console.Write("Nhập năm học: ");
                student.YearOfStudy = int.Parse(Console.ReadLine());

                Console.Write("Nhập niên khóa: ");
                student.AcademicYear = Console.ReadLine();

                Console.Write("Nhập tên trường: ");
                student.University = Console.ReadLine();

                Console.Write("Nhập ngành học: ");
                student.Major = Console.ReadLine();
            }
            else if (person is Pupil pupil)
            {
                Console.Write("Nhập tên trường: ");
                pupil.School = Console.ReadLine();

                Console.Write("Nhập lớp: ");
                pupil.Class = Console.ReadLine();
            }
            else if (person is Worker worker)
            {
                Console.Write("Nhập nơi làm việc: ");
                worker.Workplace = Console.ReadLine();

                Console.Write("Nhập lương: ");
                worker.Salary = decimal.Parse(Console.ReadLine());
            }
            else if (person is Artist artist)
            {
                Console.Write("Nhập nghệ danh: ");
                artist.StageName = Console.ReadLine();

                Console.Write("Nhập lĩnh vực chuyên môn: ");
                artist.Specialty = Console.ReadLine();
            }

            Console.WriteLine("\nThông tin đối tượng:");
            person.DisplayInfo();
        }
    }
}
