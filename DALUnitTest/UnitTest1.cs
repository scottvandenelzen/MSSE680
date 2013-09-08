using System;
using System.Collections.Generic;
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
        public void InsertUsingRepository()
        {
            var contactRepo = new DataRepository<Contact>();

            Contact myContact = new Contact();
            myContact.FirstName = "John";
            myContact.Lastname = "Smith";
            myContact.Address = "123 Easy Street";
            myContact.City = "Green Bay";
            myContact.State = "WI";
            myContact.ZipCode = "54301";

            contactRepo.Insert(myContact);
        }

        [TestMethod]
        public void InsertPhoneUsingRepository()
        {
            var phoneRepo = new DataRepository<Phone>();

            Phone myphone = new Phone();
            myphone.ContactID = 1;
            myphone.PhoneNumber = "888-8888";
            myphone.PhoneType = 1;

            phoneRepo.Insert(myphone);
        }


        [TestMethod]
        public void RetrieveUsingRepository()
        {
            var contactRepo = new DataRepository<Contact>();

            List<Contact> myList = contactRepo.GetAll().ToList<Contact>();
            Assert.IsTrue(myList.Count > 0);
        }


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
        public void DeleteContact()
        {
            scottEntities db = new scottEntities();

            Contact myContact = new Contact();

            // first add a contact i want to delete
            myContact.FirstName = "DELETEME";
            myContact.Lastname = "VandenElzen";
            myContact.Address = "123 Easy Street";
            myContact.City = "Green Bay";
            myContact.State = "WI";
            myContact.ZipCode = "54301";

            db.Contacts.Add(myContact);
            db.SaveChanges();

            Contact deleteContact = (from d in db.Contacts where d.FirstName == "DELETEME" select d).Single();
            db.Contacts.Remove(deleteContact);
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
