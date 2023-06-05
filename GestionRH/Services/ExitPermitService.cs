using GestionRH.Model;
using GestionRH.Repository;

namespace GestionRH.Services
{
    public interface IExitPermitService
    {
        Autorisation GetExitPermitRequestById(int id);
        void UpdateExitPermitRequest(Autorisation exitPermitRequest);
        // Other methods related to exit permit requests
    }

    public class ExitPermitService : IExitPermitService
    {
        private readonly IExitPermitRepository _exitPermitRepository;

        public ExitPermitService(IExitPermitRepository exitPermitRepository)
        {
            _exitPermitRepository = exitPermitRepository;
        }

        public Autorisation GetExitPermitRequestById(int id)
        {
            return _exitPermitRepository.GetById(id);
        }

        public void UpdateExitPermitRequest(Autorisation exitPermitRequest)
        {
            _exitPermitRepository.Update(exitPermitRequest);
        }

        // Implement other methods related to exit permit requests
    }
}
