using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Linq;
using DAL;

namespace DALUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // database context
            scottEntities db = new scottEntities();

            // act -- go get the first record
            Contact savedContact = (from d in db.Contacts where d.ContactID == 1 select d).Single();

            // assert
            Assert.AreEqual(savedContact.ContactID, 1);

        }
    }
}
