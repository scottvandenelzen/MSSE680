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
        public void AddContact()
        {
            scottEntities db = new scottEntities();

            Contact myContact = new Contact();

            myContact.FirstName = "Scott";
            myContact.Lastname = "VandenElzen";
            myContact.Address = "123 Easy Street";
            myContact.City = "Green Bay";
            myContact.State = "WI";
            myContact.ZipCode = "54301";

            db.Contacts.Add(myContact);
            db.SaveChanges();

            Phone myHome = new Phone();
            myHome.PhoneType = 1;
            myHome.PhoneNumber = "555-1212";
            myHome.ContactID = myContact.ContactID;

            db.Phones.Add(myHome);
            db.SaveChanges();
        }

        
        [TestMethod]
        public void LoadContact()
        {
            scottEntities db = new scottEntities();

            Contact myContact = (from d in db.Contacts where d.ContactID == 1 select d).Single();

            Assert.AreEqual(myContact.ContactID, 1);

        }
    }




}
