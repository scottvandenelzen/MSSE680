using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Business
{
    public class ContactManager
    {
        // add a contact to the table
        public void Insert(Contact oContact)
        {
            var contactRepo = Service.RepositoryFactory.Create("Contact");
            contactRepo.Insert(oContact);
        }

        public void Delete(Contact oContact)
        {
            var contactRepo = Service.RepositoryFactory.Create("Contact");
            contactRepo.Delete(oContact);
        }

        public void Update(Contact oContact)
        {
            var contactRepo = Service.RepositoryFactory.Create("Contact");
            contactRepo.Update(oContact);
        }

        public IQueryable<Contact> GetAll()
        {
            var contactRepo = Service.RepositoryFactory.Create("Contact");
            return (contactRepo.GetAll().OfType<Contact>());
        }

        public IQueryable<Contact> GetByLastName(string lastName)
        {
            var contactRepo = Service.RepositoryFactory.Create("Contact");
            return (contactRepo.GetBySpecificKey("LastName", lastName).OfType<Contact>());
        }

    }
}
