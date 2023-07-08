namespace Core.Entities
{
    public abstract class Auditable<TI> : EntityBase<TI>
    {
        public DateTime? DeletedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string DeletedBy { get; set; }
    }
}
