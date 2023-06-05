using GestionRH.Context;
using GestionRH.Model;

namespace GestionRH.Repository
{
    public interface IVacationRepository
    {
        Conge GetById(int id);
        void Update(Conge exitPermitRequest);
        // Other methods for CRUD operations on exit permit requests
    }
    public class VacationRepository : IVacationRepository
    {
        private readonly DataContext _dbContext;

        public VacationRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Conge GetById(int id)
        {
            return _dbContext.Conge.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Conge vacationRequest)
        {
            _dbContext.Conge.Update(vacationRequest);
            _dbContext.SaveChanges();
        }
    }
}
