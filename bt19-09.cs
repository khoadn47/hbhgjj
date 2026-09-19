using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public double GPA { get; set; }

        public Student() { }

        public Student(string id, string name, int age, string address, double gpa)
        {
            Id = id;
            Name = name;
            Age = age;
            Address = address;
            GPA = gpa;
        }

        public override string ToString()
        {
            return $"ID: {Id} | Tên: {Name} | Tuổi: {Age} | Địa chỉ: {Address} | GPA: {GPA}";
        }
    }

    public class StudentDAO
    {
        private List<Student> students = new List<Student>();

        public void Add(Student student)
        {
            if (GetById(student.Id) != null)
            {
                Console.WriteLine("ID đã tồn tại!");
                return;
            }

            students.Add(student);
        }

        public bool Edit(Student student)
        {
            Student oldStudent = GetById(student.Id);

            if (oldStudent == null)
                return false;

            oldStudent.Name = student.Name;
            oldStudent.Age = student.Age;
            oldStudent.Address = student.Address;
            oldStudent.GPA = student.GPA;

            return true;
        }

        public bool Delete(string id)
        {
            Student student = GetById(id);

            if (student == null)
                return false;

            students.Remove(student);
            return true;
        }

        public List<Student> GetAll()
        {
            return students;
        }

        public Student GetById(string id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public List<Student> GetByName(string name)
        {
            return students
                .Where(s => s.Name.ToLower().Contains(name.ToLower()))
                .ToList();
        }

        public List<Student> GetByGPA(double gpa)
        {
            return students
                .Where(s => s.GPA >= gpa)
                .ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StudentDAO dao = new StudentDAO();

            dao.Add(new Student("SV01", "Nguyen Van An", 20, "Ha Noi", 8.5));
            dao.Add(new Student("SV02", "Tran Van Binh", 21, "Hai Phong", 7.5));
            dao.Add(new Student("SV03", "Le Thi Hoa", 20, "Quang Ninh", 9.0));

            foreach (Student s in dao.GetAll())
            {
                Console.WriteLine(s);
            }
        }
    }
}
