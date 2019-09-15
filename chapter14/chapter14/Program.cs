using System;

namespace chapter14
{
    public class Student
    {
        public string FullName;
        public string Course;
        public string Subject;
        public string University;
        public string EMail;
        public string PhoneNumber;

        public void NewStudent ()
        {
            Console.WriteLine("This new students name is: " + FullName + "\nThe corse is: " + Course);
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            var newStudent = new Student();
            Console.WriteLine("Write you full name: ");
            newStudent.FullName = Console.ReadLine();
            Console.WriteLine("Write what corse you are taking: ");
            newStudent.Course = Console.ReadLine();
            newStudent.NewStudent();
            
        }
    }
}
