using Microsoft.AspNetCore.Identity;

namespace CargoTrack.Entity.Entities
{
    public class AppUser: IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        //Navigation Properties

        public IList<Cargo> SentCargos { get; set; }
        public IList<Cargo> ReceivedCargos { get; set; }
        public IList<Address> Addresses { get; set; }

    }
}
