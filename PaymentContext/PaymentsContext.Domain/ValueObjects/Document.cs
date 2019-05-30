using Flunt.Validations;
using PaymentsContext.Domain.Enums;
using PaymentsContext.Share.ValueObjects;

namespace PaymentsContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(
                new Contract()
                .Requires()
                .IsTrue(ValidateDocument(), "Document.Number", "Documento Inválido")
            );
        }
        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        private bool ValidateDocument()
        {
            if (Type == EDocumentType.CNPJ && Number.Length == 14)
                return true;
            if (Type == EDocumentType.CPF && Number.Length == 11)
                return true;

            return false;
        }
    }
}