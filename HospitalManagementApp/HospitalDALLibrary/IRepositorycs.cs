namespace HospitalDALLibrary
{
    public interface IRepository<K, T> where T : class
    {
        T? Add(T entity);
        IEnumerable<T> GetAll();
        T? Get(K key);
        T? Update(K key, T entity);
        void Delete(K key);
    }
}
