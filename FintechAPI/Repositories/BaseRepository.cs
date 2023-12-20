
using FintechApi.Repositoy.Interfaces;
using FintechAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace FintechApi.Repositoy
{
    public class BaseRepository : IBaseRepository
    {
        public DataBaseContext _dbContext;

        
        public BaseRepository(DataBaseContext context)
        {
            _dbContext = context;
            //_dbSet = context.Set<T>();
        }

        public void Add<T>(T model) where T : class
        {
            _dbContext.Add(model);
           
        }

        public void Remove<T>(T model) where T : class
        {
            _dbContext.Remove(model);           
        }

        
        public void Update<T>(T model) where T : class
        {
            _dbContext.Update(model);            
        }



    }
}
