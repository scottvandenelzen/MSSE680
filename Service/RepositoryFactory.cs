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



}
