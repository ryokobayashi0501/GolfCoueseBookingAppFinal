using GolfCoueseBookingApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfCoueseBookingApp.Models
{
    [Table("Course")]
    public class CourseModel
    {
        [Key]
        public Int64 CourseId { get; set; }
        public Int64 UserId { get; set; }

        [MaxLength(250)]
        public String? CourseName { get; set; }
        [MaxLength(250)]
        public String? CourseURL { get; set; }
        [MaxLength(250)]
        public String? Address { get; set; }
        [MaxLength(512)]
        public String? Description { get; set; }
        public Int64? TelephoneNumber { get; set; }

    }
}
