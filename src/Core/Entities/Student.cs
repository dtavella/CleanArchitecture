namespace Core.Entities
{
    public class Student : Auditable<long>
    {        
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
