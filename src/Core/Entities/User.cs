namespace Core.Entities
{
    public class User : Auditable<long>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
