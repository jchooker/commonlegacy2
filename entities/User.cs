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
        public string IpAddress { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string ArtistWork { get; set; }
        public string FavoriteColor { get; set; }
        public string ProfilePicture { get; set; }
        public string SymbolCombination { get; set; }
        public string LatestCreativeMantra { get; set; }
        public string Bio { get; set; }
        public bool IsModified { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
    }
}