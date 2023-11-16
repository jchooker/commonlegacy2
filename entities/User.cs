using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonLegacy.entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Gender { get; set; }
        public string IpAddress { get; set; } = null;
        public int? Age { get; set; }
        public string Country { get; set; } = null;
        public string ArtistWork { get; set; } = null;
        public string FavoriteColor { get; set; } = null;
        public string ProfilePicture { get; set; } = null;
        public string SymbolCombination { get; set; } = null;
        public string LatestCreativeMantra { get; set; } = null;
        public string Bio { get; set; } = null;
        public bool IsModified { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
    }
}