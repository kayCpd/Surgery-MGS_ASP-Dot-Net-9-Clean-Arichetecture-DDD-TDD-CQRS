using Surgery.Domain.Entities;
using Surgery.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorMgs.Test.Domain.Entities
{
    [TestClass]
    public class GPOfficeTests
    {

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_NullName_Throws()
        {
            new GPOffice(null!);
        }

    }
}
