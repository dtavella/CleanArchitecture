namespace Core.Entities
{
    public class CourseStudent
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public long StudentId { get; set; }
        public Student Student { get; set; }
    }
}
