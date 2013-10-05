using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using DAL;
using System.Linq;

namespace BusinessTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// use the contact manager to add a record
        /// </summary>
        [TestMethod]
        public void AddContact()
        {
            Contact mycontact = new Contact();
            mycontact.FirstName = "Spongebob";
            mycontact.Lastname = "SquarePants";
            mycontact.Address = "Pinneaple Under the Sea";
            mycontact.City = "Atlantis";
            mycontact.State = "VI";

            ContactManager cm = new ContactManager();
            cm.Insert(mycontact);
            
        }


        /// <summary>
        ///  use the phone manager to add a record
        /// </summary>
        [TestMethod]
        public void AddPhone()
        {
            Phone myPhone = new Phone();
            myPhone.PhoneNumber = "800-555-1212";
            myPhone.ContactID = 1;

            PhoneManager pm = new PhoneManager();
            pm.Insert(myPhone);
        }


        /// <summary>
        /// get the contact repo
        /// </summary>
        [TestMethod]
        public void GetRepo()
        {
            ContactManager cm = new ContactManager();

            var myRepo = cm.GetAll();
            int iCount = myRepo.Count();
            Assert.IsTrue(iCount>0);
        }

        [TestMethod]
        public void IsRepoFull()
        {

            ContactManager cm = new ContactManager();
            PhoneManager pm = new PhoneManager();

            var myContacts = cm.GetAll();
            var myPhones = pm.GetAll();

            var myQuery = from c in myContacts
                          join p in myPhones on c.ContactID equals p.ContactID
                          select new {c, p};
            var joinedResults = myQuery.AsQueryable();

        }


    }
}
