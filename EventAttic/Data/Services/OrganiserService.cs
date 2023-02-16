using EventAttic.Data.Base;
using EventAttic.Models;

namespace EventAttic.Data.Services
{
    public class OrganiserService : EntityBaseRepository<Organiser>, IOrganiserService
    {
        public OrganiserService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
