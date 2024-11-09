using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zilicoPOSAPI.dtos.user
{
    public class UserResponse
    {
        public int Id { get; internal set; }
        public string Name { set; get; } = String.Empty;
        public string Email { set; get; } = String.Empty;
        public string Password { set; get; } = String.Empty;
        public string Role { set; get; } = String.Empty;
        public int UserType {set ; get;}  
    }
}