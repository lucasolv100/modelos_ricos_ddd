using PaymentsContext.Domain.Entities;
using PaymentsContext.Domain.Repositories;

namespace PaymentsContext.Tests.Mocks
{
    public class FakeStudentRespository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {

        }

        public void DeleteSubscription()
        {

        }

        public bool DocumentExists(string document)
        {
            if (document == "99999999999")
                return true;
            
            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "teste@teste.com")
                return true;
            
            return false;
        }
    }
}