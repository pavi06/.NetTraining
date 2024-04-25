namespace ShoppingAppDALLibrary
{
    public abstract class AbstractRepository<K, T> : IRepository<K, T>
    {
        protected List<T> items = new List<T>();
        public virtual T Add(T item)
        {
            items.Add(item);
            Console.WriteLine("added successfully");
            return item;
        }
        public virtual ICollection<T> GetAll()
        {
            return items.ToList<T>();
        }

        public abstract T Delete(K key);

        public abstract T GetByKey(K key);

        public abstract T Update(T item);

    }
}
