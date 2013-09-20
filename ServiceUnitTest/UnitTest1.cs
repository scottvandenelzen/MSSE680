using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using DAL;

namespace ServiceUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// use the factory to create a repository and add something into it
        /// </summary>
        [TestMethod]
        public void UseFactoryToInsertIntoContactRepoTest()
        {
            Contact mycontact = new Contact();
            mycontact.FirstName = "Spongebob";
            mycontact.Lastname = "SquarePants";
            mycontact.Address = "Pinneaple Under the Sea";
            mycontact.City = "Atlantis";
            mycontact.State = "VI";

            var contactRepo = Service.RepositoryFactory.Create("Contact");
            contactRepo.Insert(mycontact);
        }

        /// <summary>
        /// use the credit card service to validate a credit card
        /// </summary>
        [TestMethod]
        public void ValidateCreditCardIsOk()
        {
            var oCC = new ValidateCreditcard(55571212, DateTime.Now, 333);
            Assert.IsTrue(oCC.Succeeded);
        }

        /// <summary>
        /// use the credit card service to validate a credit card doesn't work
        /// </summary>
        [TestMethod]
        public void ValidateCreditCardFails()
        {
            var oCC = new ValidateCreditcard(5551212, DateTime.Now, 333);
            Assert.IsFalse(oCC.Succeeded);
        }

    }
}
