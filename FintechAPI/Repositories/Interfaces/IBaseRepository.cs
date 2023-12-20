namespace FintechApi.Repositoy.Interfaces
{
    public interface IBaseRepository
    {
        public void Add<T>(T model)  where T : class;

        public void Remove<T>(T model) where T : class;

        public void Update<T>(T model) where T : class;







    }
}
