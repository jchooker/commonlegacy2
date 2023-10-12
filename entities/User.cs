using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;

namespace CommonLegacy.entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Gender { get; set; }
        [Column("ip_address")]
        public string IpAddress { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        [Column("artist_work")]
        public string ArtistWork { get; set; }
        [Column("favorite_color")]
        public string FavoriteColor { get; set; }
        [Column("profile_picture")]
        public string ProfilePicture { get; set; }
        [Column("symbol_combination")]
        public string SymbolCombination { get; set; }
        [Column("latest_creative_mantra")]
        public string LatestCreativeMantra { get; set; }
        public string Bio { get; set; }
    }
}