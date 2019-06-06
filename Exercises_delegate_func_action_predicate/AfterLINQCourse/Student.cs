using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_delegate_func_action_predicate
{
    public class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FN { get; private set; }
        public string Tel { get; private set; }
        public string Email { get; private set; }
        public List<double> Marks { get; private set; }
        public double GroupNumber { get; private set; }
        public int Age { get; private set; }

        // CONSTRUCTORS

        public Student(string firstName, string lastName, int age, string FN, string Tel, double group, string email = "")
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FN = FN;
            this.Tel = Tel;
            this.Email = email;
            this.Marks = new List<double>();
            this.GroupNumber = group;
        }
        public Student ()
        {

        }

        // METHODS
        //Problem 3. First before last: Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.Use LINQ query operators.

        public static Student[] FirstBeforeLast(List<Student> students)
        {
            return students.Where(x => x.FirstName.CompareTo(x.LastName) < 0).ToArray();
        }

        //Problem 4. Age range - Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
        public static Student[] AgeRange(List<Student> students, int low, int high)
        {
            return students.Where(x => x.Age > low && x.Age < high).ToArray();
        }

        public void SetEmail(string newMail)
        {
            Email = newMail;
        }

        public void AddMark(double mark)
        {
            Marks.Add(mark);
        }

        public override string ToString()
        {
            return string.Format($"{FirstName} {LastName} Age:{Age} FN:{FN} Tel:{Tel} Mail:{Email} Marks:{Marks} Group:{GroupNumber}"); 
        }
    }
}

