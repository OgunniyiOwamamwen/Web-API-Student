using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API_Student.Models;

namespace Web_API_Student.Controllers
{
    [RoutePrefix("students")]
    public class StudentsController : ApiController
    {
        static List<Student> students = new List<Student>()
        {
            new Student() {Id =1, Name ="Owamamwen" },
            new Student() {Id =2, Name ="Federica" },
            new Student() {Id =3, Name ="Clara" }
        };
        [Route("{Id:int}")]
        public Student Get(int Id)
        {
            return students.FirstOrDefault(s => s.Id == Id);
        }
        [HttpPost]
        [Route("students")]
        public HttpResponseMessage Post(Student student)
        {
            students.Add(student);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri + student.Id.ToString());
            return response;
        }
        [Route("{name:alpha}")]
        public Student GetName(string name)
        {
            return students.FirstOrDefault(s => s.Name.ToLower() == name.ToLower());
        }
        [Route("teachers")]
        public IEnumerable<Teacher> GetTeachers()
        {
            List<Teacher> teacher = new List<Teacher>
        {
            new Teacher() {Id =1, Name = "Paola" },
            new Teacher() {Id =2, Name = "Giorgia" },
            new Teacher() {Id =3, Name = "Sero" }
        };
            return teacher;
        }

        [Route("")]
        public IEnumerable<Student> Get()
        {
            return students;
        }
        [Route("{id}/courses")]
        public IEnumerable<string> GetStudentCourses(int Id)
        {
            if (Id == 1)
                return new List<String>() { "C#", "ASP.NET", "SQL Server" };
            else if (Id == 2)
                return new List<String>() { "ASP.NET Web API", "C#", "SQL Server" };
            else if (Id == 3)
                return new List<String>() { "Bootstrap", "jQuery", "AngularJs" };
            else
                return new List<String>() { "No course match or find" };
        }
    }
}
