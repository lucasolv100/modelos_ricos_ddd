using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentsContext.Domain.Enums;
using PaymentsContext.Domain.ValueObjects;

namespace PaymentsContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTest
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123456789456123456789", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }
        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("42272705000108", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }
        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123456789456123456789", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }
        [DataTestMethod]
        [DataRow("54128407011")]
        [DataRow("33749705089")]
        [DataRow("38535591079")]
        [DataRow("26353245068")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}