namespace Core.Entities
{
    public class Country : EntityBase<int>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
