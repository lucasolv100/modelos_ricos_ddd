using Flunt.Validations;
using PaymentsContext.Share.ValueObjects;

namespace PaymentsContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(
                new Contract()
                .Requires()
                .IsNullOrEmpty(FirstName, "Name.FirstName", "Nome inválido")
                .IsNullOrEmpty(LastName, "Name.LastName", "Sobrenome inválido")
                .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve ter pelo menos 3 caracteres")
                .HasMinLen(LastName, 3, "Name.LastName", "Sobrenome deve ter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 150, "Name.FirstName", "Nome deve ter no máximo 150 caracteres")
                .HasMaxLen(LastName, 150, "Name.LastName", "Sobrenome deve ter no máximo 150 caracteres")
            );
            

        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}