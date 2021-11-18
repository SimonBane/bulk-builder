namespace BulkBuilder.Application.Users
{
    public class UserContext : IUserContext
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Sub { get; set; }
    }
}