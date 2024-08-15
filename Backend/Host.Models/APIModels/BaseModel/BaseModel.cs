namespace Host.Models.APIModels.BaseModel
{
    public abstract class BaseModel
    {
        public virtual Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual bool IsDeactivate { get; set; }
    }
}
