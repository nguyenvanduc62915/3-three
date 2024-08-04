using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServicesAPI.DAL.Models
{
    public class PhoneNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(12)]
        public string Number { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime UpdationTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
