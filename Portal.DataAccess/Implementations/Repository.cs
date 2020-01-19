namespace Portal.DataAccess
{
    using System;
    using System.Linq;

    using Portal.Entities;

    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private DataBaseContext DataBaseContext { get; }

        public Repository(DataBaseContext dataBaseContext)
        {
            DataBaseContext = dataBaseContext;
        }

        public void Add(TEntity entity)
            => DataBaseContext.Set<TEntity>().Add(entity);

        public void Delete(long id)
        {
            var entity = Get(id);
            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), id);
            }

            Delete(entity);
        }

        public void Delete(TEntity entity)
            => DataBaseContext.Remove(entity);

        public void Update(long id, object updatedEntity)
        {
            var entity = Get(id);
            if (entity == null)
            {
                throw new Exception($"Entity {typeof(TEntity)} with identifier {id} not found");
            }

            DataBaseContext.Entry(entity).CurrentValues.SetValues(updatedEntity);
        }

        public TEntity Get(long id)
            => (TEntity)DataBaseContext.Set<TEntity>().FirstOrDefault(x => x.Id == id);

        public IQueryable<TEntity> GetAll()
            => DataBaseContext.Set<TEntity>().AsQueryable();
    }
}