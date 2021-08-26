using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystemData.Interfaces;
using StudentSystemData.Models;

namespace StudentSystemData.Repositories
{

    public class StudentDatabase : IStudentRepository
    {
        private StudentContext db = new StudentContext();

        public bool addNewStudent(Student student)
        {
            db.Student.Add(student);
            db.SaveChanges();
            return true;
        }

        public List<Student> getAllStudents()
        {
            return db.Student.ToList();
        }

        public Student getStudentByFnAndNoc(string firstname, int numOfCourses)
        {
            return db.Student.FirstOrDefault(s => s.firstname == firstname && s.numOfCourses == numOfCourses);
        }

        public Student getStudentById(int id)
        {
            return db.Student.FirstOrDefault(s => s.id == id);
        }

        public Student getStudentByLastname(string lastname)
        {
            Student student = db.Student.FirstOrDefault(s => s.lastname == lastname);

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
                db.Student.Remove(student);
                db.SaveChanges();
                return true;
            }
        }

        public List<Student> updateStudentById(int id, Student student)
        {
            bool result = removeStudentById(id);
            if (result)
            {
                addNewStudent(student);
                db.SaveChanges();
                return db.Student.ToList();
            }
            else
            {
                return null;
            }
        }

       
    }
}
