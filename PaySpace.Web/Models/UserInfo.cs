using System.ComponentModel.DataAnnotations;

namespace PaySpace.Web.Models
{
    public class UserInfo
    {
        [Required]
        public string Username { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;
    }

    public class ExternalUserInfo
    {
        [Required]
        public string Username { get; set; } = default!;

        [Required]
        public string ProviderKey { get; set; } = default!;
    }

    public record AuthToken(string Token);
}
