namespace UsersApp.Models
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UserResponse(AppUser user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
        }
    }
}
