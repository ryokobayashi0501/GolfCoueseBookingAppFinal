using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfCoueseBookingApp.Models
{
    [Table("User")]
    public class UserModel
    {
        [Key]
        public Int64 UserId { get; set; }

        public Boolean? IsActive { get; set; }

        [MaxLength(250)]
        public String? FirstName { get; set; }
        [MaxLength(250)]
        public String? LastName { get; set; }
        [MaxLength(250)]
        public String? EmailAddress { get; set; }
        [MaxLength(512)]
        public String? Password { get; set; }
        public Int64? TelephoneNumber { get; set; }

    }
}
