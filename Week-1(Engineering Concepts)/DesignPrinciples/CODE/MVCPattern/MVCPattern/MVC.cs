using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPattern
{
    class Student
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Grade { get; set; }
    }

    class StudentView
    {
        public void DisplayStudentDetails(Student s)
        {
            Console.WriteLine($"Student: {s.Name}, ID: {s.Id}, Grade: {s.Grade}");
        }
    }

    class StudentController
    {
        private Student model;
        private StudentView view;

        public StudentController(Student s, StudentView v)
        {
            model = s;
            view = v;
        }

        public void SetName(string name) => model.Name = name;
        public void UpdateView() => view.DisplayStudentDetails(model);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student model = new Student { Name = "Aditi", Id = "101", Grade = "A" };
            StudentView view = new StudentView();
            StudentController controller = new StudentController(model, view);

            controller.UpdateView();
            controller.SetName("Priya");
            controller.UpdateView();
        }
    }
}
