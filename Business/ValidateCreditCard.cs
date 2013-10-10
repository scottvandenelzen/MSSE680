using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;

namespace Business
{
    /// <summary>
    /// notice i'm inheriting from my service baseclass 
    /// </summary>
    public class ValidateCreditCard : Service.ValidateCreditcard
    {

        /// <summary>
        /// uses the constructor in the base class to create a ValidCreditCard object and call it's Validate() method
        /// </summary>
        public ValidateCreditCard(int iCardNumber, DateTime dexpirationDate, int iccvnumber) : base(iCardNumber, dexpirationDate, iccvnumber)
        {
        }
    

    }
}
