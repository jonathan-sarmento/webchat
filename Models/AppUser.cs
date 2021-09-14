using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WebChat.Models
{
    public class AppUser : IdentityUser
    {
        public List<Message> Messages { get; set; }
    }
}
