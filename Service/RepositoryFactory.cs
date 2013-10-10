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
    public class RepositoryFactory
    {
        public static IDataRepository Create(string sRepositoryType)
        {

            // setup a context and pass it in
            DbContext myContext = new DbContext(ConfigurationManager.ConnectionStrings["scottEntities"].ConnectionString);


            IDataRepository objRepo;
            switch (sRepositoryType)
            {
                case "Contact":
                    objRepo = new DataRepository<Contact>(myContext);
                    break;
                case "Phone":
                    objRepo = new DataRepository<Phone>(myContext);
                    break;
                default:
                    objRepo = null;
                    throw new System.ArgumentException("Unimplemented Repository type the factory " + sRepositoryType);
            }
            return objRepo;
        }
    }



}
