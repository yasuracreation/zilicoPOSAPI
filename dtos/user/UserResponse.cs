using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zilicoPOSAPI.dtos.User
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string Name { get; set; } // You might want to combine FirstName and LastName
        public string Email { get; set; }
        public string UserType { get; set; } // Assuming this exists in your User entity
        public string Phone { get; set; } // Optional: include if needed in response
        public DateTime CreatedAt { get; set; } // Optional: include if needed in response
        public DateTime UpdatedAt { get; set; } // Optional: include if needed in response
    }
}