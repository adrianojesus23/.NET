namespace Domains
{
    internal interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IList<TEntity> GetAll();
        TEntity Get(int id);
    }
}
