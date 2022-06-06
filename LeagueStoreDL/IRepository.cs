namespace StoreRepo
{

    public interface IRepository<T>
    {



        void Add(T p_resource);



        List<T> GetAll();

        List<T> GetSumHistory(string p_resource);
        List<T> GetStoreHistory(string p_resource);

        void update(T p_resource);

        void replenish(T p_resource);

    }
}