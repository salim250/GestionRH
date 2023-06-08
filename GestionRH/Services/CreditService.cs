using GestionRH.Model;
using GestionRH.Repository;

namespace GestionRH.Services
{
    public interface ICreditService
    {
        Credit GetCreditRequestById(int id);
        void UpdateCreditRequest(Credit creditRequest);
        // Other methods related to exit permit requests
    }
    public class CreditService : ICreditService
    {
        private readonly ICreditRepository _creditRepository;

        public CreditService(ICreditRepository creditRepository)
        {
            _creditRepository = creditRepository;
        }
        public Credit GetCreditRequestById(int id)
        {
            return _creditRepository.GetById(id);
        }

        public void UpdateCreditRequest(Credit creditRequest)
        {
            _creditRepository.Update(creditRequest);
        }
    }
}
