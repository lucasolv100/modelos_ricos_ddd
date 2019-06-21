using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentsContext.Domain.Entities;
using PaymentsContext.Domain.Enums;
using PaymentsContext.Domain.Queries;
using PaymentsContext.Domain.ValueObjects;

namespace PaymentsContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTest
    {
        private IList<Student> _students;
        public StudentQueriesTest()
        {
            _students = new List<Student>();
            
            for (int i = 0; i < 11; i++)
            {
                _students.Add(new Student(
                    new Name("Lucas", i.ToString()),
                    new Document("1111111111" + i.ToString(), EDocumentType.CPF),
                    new Email(i.ToString() + "@teste.com")
                ));
            }
        }
        
        
        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists(){
            
            var exp = StudentQueries.GetStudentInfo("12345678911");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, student);
        }
        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists(){
            
            var exp = StudentQueries.GetStudentInfo("11111111111");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, student);
        }
    }
}