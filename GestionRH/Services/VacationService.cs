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
        private readonly IVacationRepository vacationRepository;

        public VacationService(IVacationRepository vacationRepository)
        {
            vacationRepository = vacationRepository;
        }

        public Conge GetVacationRequestById(int id)
        {
            return vacationRepository.GetById(id);
        }

        public void UpdateVacationRequest(Conge vacationRequest)
        {
            vacationRepository.Update(vacationRequest);
        }
    }
}
