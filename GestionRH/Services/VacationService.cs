using GestionRH.Model;
using GestionRH.Repository;

namespace GestionRH.Services
{
    public interface IVacationService
    {
        Conge GetVacationRequestById(int id);
        void UpdateVacationRequest(Conge vacationRequest);
        // Other methods related to exit permit requests
    }
    public class VacationService : IVacationService
    {
        private readonly IVacationRepository _vacationRepository;

        public VacationService(IVacationRepository vacationRepository)
        {
            _vacationRepository = vacationRepository;
        }

        public Conge GetVacationRequestById(int id)
        {
            return _vacationRepository.GetById(id);
        }

        public void UpdateVacationRequest(Conge vacationRequest)
        {
            _vacationRepository.Update(vacationRequest);
        }
    }
}
