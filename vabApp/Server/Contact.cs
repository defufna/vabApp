using VeloxDB.ObjectInterface;

namespace vabApp.Server
{
    [DatabaseClass]
    public abstract partial class Contact : DatabaseObject
    {
        [DatabaseProperty]
        public abstract string FirstName { get; set; }

        [DatabaseProperty]
        public abstract string LastName { get; set; }

        [DatabaseProperty]
        public abstract string Email { get; set; }

        [DatabaseProperty]
        public abstract string PhoneNumber { get; set; }

        public partial vabApp.Shared.Contact ToDTO();
        public static partial Contact FromDTO(ObjectModel om, vabApp.Shared.Contact dto, bool allowUpdate = false);
    }
}