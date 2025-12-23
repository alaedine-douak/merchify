namespace Merchify.Core;

public class InMemoryRepo<TEntity>
   : IRepository<TEntity> where TEntity : BaseEntity
{
   private readonly IList<TEntity> _table;

   public InMemoryRepo()
   {
      _table = InMemoryDb.Table<TEntity>();
   }
   
   public TEntity? GetById(int id) => _table.FirstOrDefault(t => t.Id == id);

   public IList<TEntity> GetAll() => _table;
   
   public void Insert(TEntity entity)
   {
      entity.Id = _table is [] ? 1 : _table.Max(t => t.Id) + 1;
      _table.Add(entity);
   }

   public void Update(TEntity entity)
   {
      var existing = GetById(entity.Id);

      if (existing is null)
         throw new ArgumentNullException(
            $"Entity with ID {entity.Id} not found in {typeof(TEntity).Name} table");
      
      int index = _table.IndexOf(existing);
      _table[index] = entity;
   }

   public void Delete(int id)
   {
      var entity = GetById(id);
      if (entity is not null) _table.Remove(entity);
   }
}