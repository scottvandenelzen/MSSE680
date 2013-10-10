using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace Service
{
    /// <summary>
    /// this service layer utility class  -- notice it's a static class
    /// </summary>
    public static partial class ServiceUtilities
    {

        /// <summary>
        /// create a contact with multiple phones
        /// </summary>
        public static void CreateContactWithPhones(string sFirstName, string sLastName, string sAddress, string sCity, string sState, string sZipCode, string sHomePhone, string sMobilePhone, string sWorkPhone)
        {
            scottEntities db = new scottEntities();

            Contact myContact = new Contact();
            myContact.FirstName = sFirstName;
            myContact.Lastname = sLastName;
            myContact.Address = sAddress;
            myContact.City = sCity;
            myContact.State = sState;
            myContact.ZipCode = sZipCode;
            db.Contacts.Add(myContact);
            db.SaveChanges();                   // I need this to update the myContact object with the new ContactID

            if (sHomePhone.Length > 0)
            {
                Phone myHPhone = new Phone();
                myHPhone.ContactID = myContact.ContactID;
                myHPhone.PhoneNumber = sHomePhone;
                myHPhone.PhoneType = 1;
                db.Phones.Add(myHPhone);
            }

            if (sMobilePhone.Length > 0)
            {
                Phone myCPhone = new Phone();
                myCPhone.ContactID = myContact.ContactID;
                myCPhone.PhoneNumber = sMobilePhone;
                myCPhone.PhoneType = 2;
                db.Phones.Add(myCPhone);
            }

            if (sWorkPhone.Length > 0)
            {
                Phone myWPhone = new Phone();
                myWPhone.ContactID = myContact.ContactID;
                myWPhone.PhoneNumber = sWorkPhone;
                myWPhone.PhoneType = 3;
                db.Phones.Add(myWPhone);
            }

            db.SaveChanges();


        }
    }
}
