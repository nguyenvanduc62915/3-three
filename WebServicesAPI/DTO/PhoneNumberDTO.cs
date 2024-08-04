using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebServicesAPI.DAL.Models;

namespace WebServicesAPI.DTO
{
    public class PhoneNumberDTO
    {
        public string? Number { get; set; }
    }
}
