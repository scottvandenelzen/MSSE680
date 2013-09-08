using System;
using System.Collections.ObjectModel;
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
        public void CreateContact()
        {
            Contact myContact = new Contact();

            myContact.FirstName = "Scott";
            myContact.Lastname = "VandenElzen";
            myContact.Address = "123 Easy Street";
            myContact.City = "Green Bay";
            myContact.State = "WI";
            myContact.ZipCode = "54301";

            Phone myMobile = new Phone();
            myMobile.PhoneNumber = "555-1212";
            myMobile.PhoneType = 1;
            myMobile.ContactID = myContact.ContactID;

            Assert.AreEqual(myMobile.ContactID, myContact.ContactID);

        }

        [TestMethod]
        public void AddToCollection()
        {
            Contact myContact = new Contact();
            myContact.FirstName = "Scott";
            myContact.Lastname = "VandenElzen";
            myContact.Address = "123 Easy Street";
            myContact.City = "Green Bay";
            myContact.State = "WI";
            myContact.ZipCode = "54301";

            Phone myMobile = new Phone();
            myMobile.PhoneNumber = "555-1212";
            myMobile.PhoneType = 1;
            myMobile.ContactID = myContact.ContactID;
            myContact.Phones.Add(myMobile);

            Phone myHome = new Phone();
            myMobile.PhoneNumber = "867-5309";
            myMobile.PhoneType = 2;
            myMobile.ContactID = myContact.ContactID;
            myContact.Phones.Add(myHome);

            Assert.AreEqual(myContact.Phones.Count,2);
        }


        [TestMethod]
        public void TestMethod2()
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
