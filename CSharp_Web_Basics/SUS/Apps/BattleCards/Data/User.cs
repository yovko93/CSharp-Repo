using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BattleCards.Data
{
    public class User //: IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            //this.Role = IdentityRole.User;
            this.Cards = new HashSet<UserCard>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        //public IdentityRole Role { get; set; }

        public virtual ICollection<UserCard> Cards { get; set; }
    }
}
