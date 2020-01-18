namespace Portal.DataAccess
{
    using System.Linq;

    using Portal.Entites;

    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        void Add(TEntity entity);

        void Delete(long id);

        void Delete(TEntity entity);

        TEntity Get(long id);

        void Update(long id, object updatedModel);

        IQueryable<TEntity> GetAll();
    }
}