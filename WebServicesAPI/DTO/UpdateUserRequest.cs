namespace WebServicesAPI.DTO
{
    public class UpdateUserRequest
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime? UpdationTime { get; set; } = DateTime.UtcNow;
        public ICollection<PhoneNumberDTO>? PhoneNumberDTO { get; set; }
        public ICollection<AddressDTO>? AddressDTO { get; set; }
    }
}
