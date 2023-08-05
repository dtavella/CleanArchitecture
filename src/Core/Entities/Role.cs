namespace Core.Entities
{
    public class Role : EntityBase<int>
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; } = new HashSet<RolePermission>();
    }
}
