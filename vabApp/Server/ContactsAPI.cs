using VeloxDB.ObjectInterface;
using VeloxDB.Protocol;
using DTO = vabApp.Shared;

namespace vabApp.Server
{
    [DbAPI]
    public class ContactsAPI
    {
        [DbAPIOperation]
        public long Add(ObjectModel om, DTO.Contact toAdd)
        {
            // Creates new contact in the database using the data in toAdd DTO
            Contact newContact = Contact.FromDTO(om, toAdd);
            return newContact.Id;
        }

        [DbAPIOperation]
        public List<DTO.Contact> GetContacts(ObjectModel om)
        {
            // Gets all contacts in the database, converts them to DTOs and returns them
            return new List<DTO.Contact>(om.GetAllObjects<Contact>().Select(c=>c.ToDTO()));
        }

        [DbAPIOperation]
        public DTO.Contact? GetContact(ObjectModel om, long id)
        {
            Contact? c = om.GetObject<Contact>(id);

            // GetObject returns null if the object does not exist in the database
            if (c == null)
                return null;

            return c.ToDTO();
        }

        [DbAPIOperation]
        public bool Update(ObjectModel om, DTO.Contact toUpdate)
        {
            // Checks if the object with given id exists in the database
            if(om.GetObject<Contact>(toUpdate.Id) == null)
                return false;

            // FromDTO can update an object if it's 3rd argument (allowUpdate) is set to true.
            // It will fetch an object from the db and update all its properties with values from the dto.
            Contact.FromDTO(om, toUpdate, true);
            return true;
        }

        [DbAPIOperation]
        public bool Delete(ObjectModel om, long id)
        {
            Contact? c = om.GetObject<Contact>(id);

            // If the object with given id does not exist in the database, return false
            if (c == null)
                return false;

            // Delete the object
            c.Delete();
            return true;
        }
    }
}
