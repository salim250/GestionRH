using GestionRH.Context;
using GestionRH.Model;

namespace GestionRH.Repository
{
    public interface IExitPermitRepository
    {
        Autorisation GetById(int id);
        void Update(Autorisation exitPermitRequest);
        // Other methods for CRUD operations on exit permit requests
    }

    public class ExitPermitRepository : IExitPermitRepository
    {
        private readonly DataContext _dbContext;

        public ExitPermitRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Autorisation GetById(int id)
        {
            return _dbContext.Autorisation.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Autorisation exitPermitRequest)
        {
            _dbContext.Autorisation.Update(exitPermitRequest);
            _dbContext.SaveChanges();
        }

        // Implement other methods for CRUD operations on exit permit requests
    }
}
