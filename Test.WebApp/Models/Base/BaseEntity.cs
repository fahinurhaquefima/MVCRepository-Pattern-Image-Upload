namespace Test.WebApp.Models.Base;

public abstract class BaseEntity<TId>
{
    public TId Id { get; set; }
}
public class BaseEntity : BaseEntity<long> { }

