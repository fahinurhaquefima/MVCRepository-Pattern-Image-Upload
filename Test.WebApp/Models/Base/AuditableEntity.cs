namespace Test.WebApp.Models.Base;

public class AuditableEntity<TId>:BaseEntity
{
    public AuditableEntity()=> IsDelete = false;
    public DateTimeOffset CreatedDate { get; set; }
    public long CreatedBy { get; set; }
    public DateTimeOffset? ModifiedDate { get; set; }
    public long? ModifiedBy { get; set; }
    public bool IsDelete { get; set; }
}
public class AuditableEntity: AuditableEntity<long> { }
