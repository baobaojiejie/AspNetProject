using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystemData.Interfaces;
using StudentSystemData.Models;

namespace StudentSystemData.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> students = new List<Student>()
        {
            new Student() {id = 1, firstname = "John", lastname = "Smith"},
            new Student() {id = 2, firstname = "Ann", lastname = "Mary"}
        };

        public bool addNewStudent(Student student)
        {
            students.Add(student);
            return true;
        }

        public List<Student> getAllStudents()
        {
            return students;
        }

        public Student getStudentByFnAndNoc(string firstname, int numOfCourses)
        {
            throw new NotImplementedException();
        }

        public Student getStudentById(int id)
        {
            Student student = students.FirstOrDefault(s => s.id == id);
            return student;
        }

        public Student getStudentByLastname(string lastname)
        {
            
            Student student = students.FirstOrDefault(s => s.lastname == lastname);
            
            return student;
        }

        public bool removeStudentById(int id)
        {
            Student student = getStudentById(id);
            if (student == null)
            {
                return false;
            }
            else
            {
                students.Remove(student);
                return true;
            }
        }

        public List<Student> updateStudentById(int id, Student student)
        {
            bool result = removeStudentById(id);
            if (result)
            {
                addNewStudent(student);
                return students;
            }
            else
            {
                return null;
            }
        }
    }
}
