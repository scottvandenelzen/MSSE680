using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;

namespace Business
{
    public static class CreateContactBL
    {
        /// <summary>
        /// create a static function that calls my service layer to insert a contact with phones
        /// </summary>
        public static void CreateContact(string sFirstName, string sLastName, string sAddress, string sCity, string sState, string sZipCode, string sHomePhone, string sMobilePhone, string sWorkPhone)
        {
            Service.ServiceUtilities.CreateContactWithPhones(sFirstName, sLastName, sAddress, sCity, sState, sZipCode, sHomePhone, sMobilePhone, sWorkPhone);

        }

    }
}
