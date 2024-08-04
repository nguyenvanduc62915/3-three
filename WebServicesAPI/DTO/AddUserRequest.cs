namespace WebServicesAPI.DTO
{
    public class AddUserRequest
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public ICollection<PhoneNumberDTO>? PhoneNumberDTO { get; set; }
        public ICollection<AddressDTO>? AddressDTO { get; set; }
    }
}
