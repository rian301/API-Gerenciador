namespace Black.Application.DTO
{
    public class UserListDTO
    {
        public int? Id { get; set; }
        public int? UserProfileId { get; set; }
        public string Email { get; set; }
        //public string Username { get; set; }
        public string Name { get; set; }
        //public string ProfileName { get; set; }
        //public string PhoneNumber { get; set; }
        public bool Active { get; set; }
    }
}
