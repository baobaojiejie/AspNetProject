using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using StudentSystem.Models;
using StudentSystemData.Interfaces;
using StudentSystemData.Models;
using StudentSystemData.Repositories;

namespace StudentSystem.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class StudentController : ApiController
    {

        //private IStudentRepository studentRepository = new StudentRepository();

        private IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRep)
        {
            studentRepository = studentRep;
        }


        // GET api/student
        public IEnumerable<Student> Get()
        {
            return studentRepository.getAllStudents();
        }

        // GET api/student/id
        public IHttpActionResult Get(int id)
        {
            Student student = studentRepository.getStudentById(id);

            if (student==null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // GET api/student/lastname
        public IHttpActionResult Get(string lastname)
        {
            Student student = studentRepository.getStudentByLastname(lastname);


            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(student);
            }

        }

        [HttpPost]
        // POST api/student
        public IHttpActionResult Post(Student student)
        {
            bool result = studentRepository.addNewStudent(student);

            if (result)
            {
                return Ok(studentRepository);
            }

            return BadRequest();
        }


        [HttpDelete]
        // DELETE api/student/id
        public IHttpActionResult Delete(int id)
        {
            bool result = studentRepository.removeStudentById(id);
            if (result)
            {
                return Ok(studentRepository.getAllStudents());
            }
            else
            {
                return NotFound();
            }
        }

     


        [HttpPut]
        // PUT api/student/id
        public IHttpActionResult Put(int id,Student student)
        {
            var studentList = studentRepository.updateStudentById(id, student);

            if (studentList!=null)
            {
                return Ok(studentList);
            }
            else
            {
                return NotFound();
                ;
            }
        }


        // GET api/student/firstname&numOfCourses
        public IHttpActionResult Get(string firstname,int numOfCourses)
        {
            Student student = studentRepository.getStudentByFnAndNoc(firstname, numOfCourses);


            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(student);
            }

        }
    }
}
