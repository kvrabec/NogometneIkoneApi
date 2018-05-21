using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace NogometneIkone.Model
{
    public class AppUser : IdentityUser
    {
        [ForeignKey("Club")]
        public int FaveriteClubID { get; set; }
        public Club FavouriteClub { get; set; }
        public int QuizzesPlayed { get; set; }
    }
}
