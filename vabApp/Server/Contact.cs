using VeloxDB.ObjectInterface;

namespace vabApp.Server
{
    [DatabaseClass]
    public abstract class Contact : DatabaseObject
    {
        [DatabaseProperty]
        public abstract string FirstName { get; set; }

        [DatabaseProperty]
        public abstract string LastName { get; set; }

        [DatabaseProperty]
        public abstract string Email { get; set; }

        [DatabaseProperty]
        public abstract string PhoneNumber { get; set; }

    }
}