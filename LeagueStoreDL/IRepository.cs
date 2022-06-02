namespace StoreRepo
{

    public interface IRepository<T>
    {



        void Add(T p_resource);



        List<T> GetAll();

        void update(T p_resource);

        void replenish(T p_resource);
    }
}