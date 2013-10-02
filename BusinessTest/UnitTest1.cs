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


        [TestMethod]
        public void AddPhone()
        {
            Phone myPhone = new Phone();
            myPhone.PhoneNumber = "800-555-1212";
            myPhone.ContactID = 1;

            PhoneManager pm = new PhoneManager();
            pm.Insert(myPhone);

        }


        [TestMethod]
        public void GetRepo()
        {
            ContactManager cm = new ContactManager();

            var myRepo = cm.GetAll();
            int iCount = myRepo.Count();
            Assert.IsTrue(iCount>0);
        }


    }
}
