using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Service
{
    public class RepositoryFactory
    {
        public static IDataRepository Create(string sRepositoryType)
        {
            IDataRepository objRepo;
            switch (sRepositoryType)
            {
                case "Contact":
                    objRepo = new DataRepository<Contact>();
                    break;
                case "Phone":
                    objRepo = new DataRepository<Phone>();
                    break;
                default:
                    objRepo = null;
                    throw new System.ArgumentException("Unimplemented Repository type the factory " + sRepositoryType);
            }
            return objRepo;
        }
    }

    /// <summary>
    /// this service layer class will validate a credit card
    /// </summary>
    public class ValidateCreditcard
    {

        public String ValidationMessage { get; set; }
        public Boolean Succeeded { get; set; }

        // contstructor
        public ValidateCreditcard(int iCardNumber, DateTime dexpirationDate, int iccvnumber )
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
    }

}
