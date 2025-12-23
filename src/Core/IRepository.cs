namespace Merchify.Core;

public interface IRepository<TEntity> 
   where TEntity : BaseEntity
{
   TEntity? GetById(int id);
   IList<TEntity> GetAll();
   void Insert(TEntity entity);
   void Update(TEntity entity);
   void Delete(int id);
}