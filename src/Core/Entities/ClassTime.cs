namespace Core.Entities
{
    public class ClassTime : Auditable<int>
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int CourseId { get; set; }


        public Course Course { get; set; }
    }
}
