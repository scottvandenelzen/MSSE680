using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Business
{
    public class PhoneManager
    {
        // add a Phone to the table
        public void Insert(Phone oPhone)
        {
            var PhoneRepo = Service.RepositoryFactory.Create("Phone");
            PhoneRepo.Insert(oPhone);
        }

        public void Delete(Phone oPhone)
        {
            var PhoneRepo = Service.RepositoryFactory.Create("Phone");
            PhoneRepo.Delete(oPhone);
        }

        public void Update(Phone oPhone)
        {
            var PhoneRepo = Service.RepositoryFactory.Create("Phone");
            PhoneRepo.Update(oPhone);
        }

        public IQueryable<Phone> GetAll()
        {
            var PhoneRepo = Service.RepositoryFactory.Create("Phone");
            return (PhoneRepo.GetAll().OfType<Phone>());
        }

    }
}
