using Surgery.Domain.Entities;
using Surgery.Domain.Exceptions;
using Surgery.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorMgs.Test.Domain.Entities
{
    [TestClass]
    public class PatientTests
    {

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_NullName_Throws()
        {
            var email = new Email("felipe@example.com");
            new Patient(null!, email);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_NullEmail_Throws()
        {
            new Patient("Felipe", email: null!);
        }

        [TestMethod]
        public void Constructor_ValidPatient_NoExceptions()
        {
            var email = new Email("felipe@example.com");
            new Patient("Felipe", email);
        }
    }
}
