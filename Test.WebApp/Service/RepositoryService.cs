
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test.WebApp.DatabaseContext;
using Test.WebApp.Models.Base;

namespace Test.WebApp.Service
{
    public class RepositoryService<TEntity, IModel> : IRepositoryService<TEntity, IModel> where TEntity : AuditableEntity, new() where IModel : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly StudentDbContext dbContext;

        public RepositoryService(StudentDbContext dbContext,IMapper mapper)
        {
            _mapper= mapper;
            this.dbContext = dbContext;
            Dbset=dbContext.Set<TEntity>();
        }
        public DbSet<TEntity> Dbset { get; }
        public async Task<IModel> DeleteAsync(long id, CancellationToken cancellationToken)
        {
            var entity = await Dbset.FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            entity.IsDelete = true;
            Dbset.Update(entity);
            await dbContext.SaveChangesAsync(cancellationToken);
            var deleteModel = _mapper.Map<TEntity, IModel>(entity);
            return deleteModel;
        }

        public async Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entites = await Dbset.Where(x=>!x.IsDelete).ToListAsync(cancellationToken);
            if (entites == null) return null;
            var data = _mapper.Map<IEnumerable<IModel>>(entites);
            return data;
        }

        public async Task<IModel> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            var entity = await Dbset.FindAsync(id);
            if (entity == null) return null;
            var model = _mapper.Map<TEntity, IModel>(entity);
            return model;
        }

        public async Task<IModel> InsertAsync(IModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<IModel, TEntity>(model);
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = 56454;
            Dbset.Add(entity);
            await dbContext.SaveChangesAsync(cancellationToken);
            var insertModel = _mapper.Map<TEntity, IModel>(entity);
            return insertModel;
        }

        public async Task<IModel> UpdateAsync(long id, IModel model, CancellationToken cancellationToken)
        {
            var entity = await Dbset.FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            entity.ModifiedDate = DateTime.Now;
            _mapper.Map(model, entity);

            await dbContext.SaveChangesAsync(cancellationToken);

            var updatedModel = _mapper.Map<TEntity, IModel>(entity);
            return updatedModel;
        }
    }
}
