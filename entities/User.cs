﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommonLegacy.entities
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
    }
}