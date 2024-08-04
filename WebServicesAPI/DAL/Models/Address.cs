using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServicesAPI.DAL.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required,MaxLength(200)]
        public string Location { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime UpdationTime {  get; set; } 
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
