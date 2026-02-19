using Surgery.Domain.Entities; 
// Add this using directive to bring the Doctor type into scope
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
    public class DoctorTests
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_NullName_Throws()
        {
            var email = new Email("felipe@example.com");
            new Doctor(null!, email);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_NullEmail_Throws()
        {
       
            new Doctor("kaykay", email: null!);
        }

        [TestMethod]
        public void Constructor_ValidDoctor_NoExceptions()
        {
            var email = new Email("felipe@example.com");

            new Doctor("Felipe", email);           

        }
    }
}
