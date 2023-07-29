using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class StudentEditDto : StudentAddEditDto
    {
        public long Id { get; set; }
    }

    public abstract class StudentAddEditDto
    {
        [Required(ErrorMessage = "ErrNameRequired")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ErrLastNameRequired")]
        [StringLength(10)]
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string CountryCode { get; set; }
    }
}
