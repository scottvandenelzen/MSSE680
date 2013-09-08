using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System.Data;
using System.Linq;

namespace DALUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            scottEntities db = new scottEntities();

            Contact myContact = (from d in db.Contacts where d.ContactID == 1 select d).Single();

            Assert.AreEqual(myContact.ContactID, 1);

        }
    }
}
