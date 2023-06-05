using GestionRH.Context;
using GestionRH.Model;

namespace GestionRH.Repository
{
    public interface ICreditRepository
    {
        Credit GetById(int id);
        void Update(Credit creditRequest);
        // Other methods for CRUD operations on exit permit requests
    }
    public class CreditRepository : ICreditRepository
    {
        private readonly DataContext _dbContext;

        public CreditRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Credit GetById(int id)
        {
            return _dbContext.Credit.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Credit creditRequest)
        {
            _dbContext.Credit.Update(creditRequest);
            _dbContext.SaveChanges();
        }
    }
}
