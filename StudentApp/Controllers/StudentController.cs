using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentDataAccess;

namespace StudentApp.Controllers
{
    public class StudentController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (StudentDbEntities entities = new StudentDbEntities())
            {
                return Ok(entities.StudentTables.ToList());
            }
        }
        public IHttpActionResult Post([FromBody]StudentTable student)
        {
            using (StudentDbEntities entities = new StudentDbEntities())
            {
                entities.StudentTables.Add(student);
                entities.SaveChanges();
                return Ok(entities.StudentTables.ToList());
            }
        }
        public IHttpActionResult Put(int id, [FromBody]StudentTable student)
        {
            using (StudentDbEntities entities = new StudentDbEntities())
            {
                var entity = entities.StudentTables.FirstOrDefault(s => s.StudentId == id);
                if (entity == null)
                {
                    return BadRequest("enter valid id");
                }
                else
                {
                    entity.StudentName = student.StudentName;
                    entity.Course = student.Course;
                    entity.Marks = student.Marks;
                    entities.SaveChanges();
                    return Ok(entities.StudentTables.ToList());
                }
            }
        }

        public IHttpActionResult Delete(int id)
        {
            using (StudentDbEntities entities = new StudentDbEntities())
            {
                var entity = entities.StudentTables.FirstOrDefault(s => s.StudentId == id);

                if (entity == null)
                {
                    return BadRequest("enter valid id");
                }
                else
                {
                    entities.StudentTables.Remove(entity);
                    entities.SaveChanges();
                    return Ok(entities.StudentTables.ToList());
                }
            }
        }
    }

    }

