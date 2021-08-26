using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystemData.Models;

namespace StudentSystemData.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> getAllStudents();
        Student getStudentById(int id);
        Student getStudentByLastname(string lastname);
        bool addNewStudent(Student student);
        bool removeStudentById(int id);
        List<Student> updateStudentById(int id, Student student);
        Student getStudentByFnAndNoc(string firstname, int numOfCourses);
    }
}
