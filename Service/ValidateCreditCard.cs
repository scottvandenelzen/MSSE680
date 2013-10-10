using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

    /// <summary>
    /// this service layer class will validate a credit card
    /// </summary>
    public class ValidateCreditcard
    {

        public String ValidationMessage { get; set; }
        public Boolean Succeeded { get; set; }

        private int CreditCardNumber;
        private DateTime ExpirationDate;
        private int CCVNumber;

        private void Validate(int iCardNumber, DateTime dexpirationDate, int iccvnumber)
        {
            if (iCardNumber.ToString().Contains("7"))
            {
                Succeeded = true;
                ValidationMessage = "It contained a 7 and that's lucky";
            }
            else
            {
                Succeeded = false;
                ValidationMessage = "Validation Failed";
            }

        }

        /// <summary>
        /// constructor that calls validate
        /// </summary>
        public ValidateCreditcard(int iCardNumber, DateTime dexpirationDate, int iccvnumber)
        {
            CreditCardNumber = iCardNumber;
            ExpirationDate = dexpirationDate;
            CCVNumber = iccvnumber;

            Validate(iCardNumber, dexpirationDate, iccvnumber);
        }

        /// <summary>
        /// empty contstructor
        /// </summary>
        public ValidateCreditcard()
        {
            
        }
    }
}

