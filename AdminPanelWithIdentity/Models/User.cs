using Microsoft.AspNetCore.Identity;
using System;

namespace AdminPanelWithIdentity.Models
{
    public class User : IdentityUser
    {
        public DateTime LastLoginTime { get; set; }
        public DateTime RegistrationTime { get; set; }
        public StatusTypes Status { get; set; }
    }
}
