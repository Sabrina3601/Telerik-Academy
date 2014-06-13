using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Task1
//Define a class Student, which contains data about a student – 
//first, middle and last name, SSN, permanent address, mobile phone e-mail,
//course, specialty, university, faculty. Use an enumeration for the specialties,
//universities and faculties. Override the standard methods, inherited by  System.Object: Equals(), 
//ToString(), GetHashCode() and operators == and !=.

//Task2
//Add implementations of the ICloneable interface. 
//The Clone() method should deeply copy all object's fields into a new object of type Student.

//Task3
//Implement the  IComparable<Student> interface to compare students by names 
//(as first criteria, in lexicographic order) and by social security number (as second criteria, in increasing order).


namespace _06.CommonTypeSystem
{
    public class Student :ICloneable, IComparable<Student>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Course { get; set; }
        public Speciality Speciality { get; set; }
        public University University { get; set; }
        public Faculties Faculty { get; set; }


        public Student(string firstName, string middleName, string lastName, string ssn, string address, string phone,
            string email, int course, Speciality speciality, University university, Faculties faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.Course = course;
            this.Speciality = speciality;
            this.University = university;
            this.Faculty = faculty;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Student))
            {
                return false;
            }
            Student student = obj as Student;
            if (student.FirstName != this.FirstName || student.LastName != this.LastName ||
                student.MiddleName != this.MiddleName || student.SSN != this.SSN)
            {
                return false;
            }
            return true;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.Course;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Student's name is : {0} {1} {2}. ", this.FirstName, this.MiddleName, this.LastName);
            sb.AppendFormat("Student's SSN is : {0}. ", this.SSN);
            sb.AppendFormat("Student's phone is : {0}. ", this.Phone);
            sb.AppendFormat("Student's email is : {0}. ", this.Address);
            sb.AppendFormat("Student is in : {0} course, speciality {1}, faculty {2}, university {3}. ",
                this.Course, this.Speciality, this.Faculty, this.University);
            return sb.ToString();
        }

        public static bool operator ==(Student a, Student b)
        {
            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            //Using Equals() - both are equals 
            return a.Equals(b);
        }

        public static bool operator !=(Student a, Student b)
        {
            return !(a.Equals(b));
        }

        public Student Clone()
        {
            Student cloneStudent = new Student(this.FirstName,this.MiddleName, this.LastName,this.SSN,this.Address,
                this.Phone, this.Email, this.Course, this.Speciality, this.University, this.Faculty);
            return cloneStudent;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public int CompareTo(Student student)
        {
            if (this.FirstName != student.FirstName)
            {
                return this.FirstName.CompareTo(student.FirstName);
            }
            if (this.MiddleName != student.MiddleName)
            {
                return this.MiddleName.CompareTo(student.MiddleName);
            }
            if (this.LastName != student.LastName)
            {
                return this.LastName.CompareTo(student.LastName);
            }
            if (this.SSN != student.SSN)
            {
                return this.SSN.CompareTo(student.SSN);
            }
            return 0;
        }
    }
}
