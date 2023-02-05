using Microsoft.AspNetCore.Mvc;
using vabApp.Shared;
using VeloxDB.AspNet;
using VeloxDB.Client;
using VeloxDB.Protocol;

namespace vabApp.WebAPI
{
    [Forward(typeof(RouteAttribute), "/api/Contacts/[action]")]
    [DbAPI(Name = "vabApp.Server.ContactsAPI")]
    public interface ContactsAPI
    {

        [DbAPIOperation]
        DatabaseTask<long> Add(Contact toAdd);

        [HttpGet]
        [DbAPIOperation]
        DatabaseTask<List<Contact>> GetContacts();

        [HttpGet]
        [DbAPIOperation]
        DatabaseTask<Contact?> GetContact(long id);

        [DbAPIOperation]
        DatabaseTask<bool> Update(Contact toUpdate);

        [HttpDelete]
        [DbAPIOperation]
        DatabaseTask<bool> Delete(long id);
    }
}
