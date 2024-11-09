using System.ComponentModel.DataAnnotations;

namespace zilicoPOSAPI.dtos.User
{
    public class UpdateUserRequest
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot be over 100 characters")]
        public string Name { set; get; } = string.Empty;

        [Required]
        public string Email { set; get; } = string.Empty;

        [Required]
        public string Password { set; get; } = string.Empty;

        [Required]
        public string Role { set; get; } = string.Empty;

        [Required]
        public int UserType { set; get; }

        // Optional relationship IDs
        public int? RoleGroupId { get; set; }
        public int? UserGroupId { get; set; }
    }
}
