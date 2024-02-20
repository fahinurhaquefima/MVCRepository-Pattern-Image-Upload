using Test.WebApp.Models.Base;

namespace Test.WebApp.Service;

public interface IRepositoryService<TEntity,IModel> where TEntity : AuditableEntity, new() where IModel : BaseEntity
{
    Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken);   
    Task<IModel> InsertAsync(IModel model,CancellationToken cancellationToken);
    Task<IModel> UpdateAsync(long id,IModel model,CancellationToken cancellationToken);
    Task<IModel> DeleteAsync(long id,CancellationToken cancellationToken);
    Task<IModel> GetByIdAsync(long id,CancellationToken cancellationToken);
}
