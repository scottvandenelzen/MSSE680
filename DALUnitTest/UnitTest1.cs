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
        /// <summary>
        /// unit test inserting using a repository
        /// </summary>
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


        // insert a phone into the repo
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


        /// <summary>
        /// retrieve data from the repo
        /// </summary>
        [TestMethod]
        public void RetrieveUsingRepository()
        {
            var contactRepo = new DataRepository<Contact>();

            List<Contact> myList = contactRepo.GetAll().ToList<Contact>();
            Assert.IsTrue(myList.Count > 0);
        }

        /// <summary>
        /// this test mehtod 
        /// </summary>
        [TestMethod]
        public void UpdateRepository()
        {
            // load the list
            var contactRepo = new DataRepository<Contact>();
            List<Contact> myList = contactRepo.GetAll().ToList<Contact>();

            // make a change and write it out
            myList[0].FirstName = "Benjamin";
            contactRepo.Update(myList[0]);

            // reload the list after hte update
            myList = contactRepo.GetAll().ToList<Contact>();

            Assert.AreEqual(myList[0].FirstName,"Benjamin");


        }


        [TestMethod]
        public void DeleteAllPeopleNamedScott()
        {
            // load the list of everyone named scott
            var contactRepo = new DataRepository<Contact>();
            List<Contact> myList = contactRepo.GetBySpecificKey("FirstName","Scott").ToList<Contact>();

            var PhoneRepo = new DataRepository<Phone>();

            // delete all the records in this list
            for (int i = 0; i < myList.Count; ++i)
            {
                // get a list of phones for this contact
                List<Phone> myPhones = PhoneRepo.GetBySpecificKey("ContactID", myList[i].ContactID).ToList<Phone>();

                //delete the phones for this contact
                for (int j = 0; j < myPhones.Count; ++j)
                {
                    PhoneRepo.Delete(myPhones[j]);
                }

                // now delete the contact
                contactRepo.Delete(myList[i]);
            }

            // reload the list (should be empty now)
            myList = contactRepo.GetBySpecificKey("FirstName","Scott").ToList<Contact>();

            Assert.AreEqual(myList.Count, 0);


        }

        /// <summary>
        ///  add a contact using the domain object and context
        /// </summary>
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

        /// <summary>
        ///  delete a contact using the domain object and context
        /// </summary>
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

            // use linq to find the object i want to delete
            Contact deleteContact = (from d in db.Contacts where d.FirstName == "DELETEME" select d).Single();
            db.Contacts.Remove(deleteContact);
            db.SaveChanges();

        }



        /// <summary>
        /// use link to find an object 
        /// </summary>
        [TestMethod]
        public void LoadContact()
        {
            scottEntities db = new scottEntities();

            Contact myContact = (from d in db.Contacts where d.ContactID == 1 select d).Single();

            Assert.AreEqual(myContact.ContactID, 1);

        }
    }
}
