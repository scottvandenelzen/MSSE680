using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;

namespace Business
{
    public class ValidateCreditCard
    {
        public bool Succeeded;
        public string ValidationMessage;

        /// <summary>
        /// create a credit card validator object and call validate
        /// </summary>
        public ValidateCreditCard(int iCardNumber, DateTime dexpirationDate, int iccvnumber)
        {
            Service.ValidateCreditcard oCreditcard = new ValidateCreditcard(iCardNumber, dexpirationDate, iccvnumber);
            Succeeded = oCreditcard.Succeeded;
            ValidationMessage = oCreditcard.ValidationMessage;
        }

    }
}
