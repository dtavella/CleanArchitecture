namespace Core.Entities
{
    public class Country : EntityBase<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
