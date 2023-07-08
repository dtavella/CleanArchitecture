namespace Core.Entities
{
    public class Course : Auditable<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<ClassTime> ClassTimes { get; set; } = new HashSet<ClassTime>();
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();

    }
}
