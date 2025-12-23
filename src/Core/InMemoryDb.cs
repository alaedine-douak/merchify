using System.Collections.Concurrent;

namespace Merchify.Core;

public static class InMemoryDb
{
   private static readonly IDictionary<Type, object> _tables = 
      new ConcurrentDictionary<Type, object>();

   public static IList<T> Table<T>() where T : BaseEntity
   {
      var type = typeof(T);
      
      if (!_tables.ContainsKey(type))
      {
         _tables[type] = new List<T>();
      }
      
      return (IList<T>)_tables[type];
   }
}