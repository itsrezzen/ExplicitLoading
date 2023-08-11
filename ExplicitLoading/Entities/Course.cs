namespace ExplicitLoading.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }

        public ICollection<TeacherCourse> TeacherCourses { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
