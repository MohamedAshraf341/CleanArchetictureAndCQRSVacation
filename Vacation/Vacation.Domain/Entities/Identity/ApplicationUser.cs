using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vacation.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public ICollection<VacationRequest> VacationRequests { get; set; }
    }
}
