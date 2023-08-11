using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitLoading
{
    public class EFService
    {
        private readonly MyDbContext _dbContext;

        public EFService(
            MyDbContext dbContext
            )
        {
            _dbContext = dbContext;
        }

        public void PrintTeachersWithCoursesAndTags()
        {
            var result = _dbContext.TeacherCourses.ToList();

            foreach (var teacherCourse in result)
            {
                _dbContext.Entry(teacherCourse).Reference(x => x.Teacher).Load();
                _dbContext.Entry(teacherCourse).Reference(x => x.Course).Load();

                Console.WriteLine("The Teacher Name Is : " + teacherCourse.Teacher.FirstName + " " + teacherCourse.Teacher.LastName + " And The Course Is : " + teacherCourse.Course.Title);

                _dbContext.Entry(teacherCourse.Course).Collection(x => x.Tags).Load();
                foreach (var courseTag in teacherCourse.Course.Tags)
                {
                    Console.WriteLine("Tag Title Is : " + courseTag.Title);
                }
            }
        }
    }
}
