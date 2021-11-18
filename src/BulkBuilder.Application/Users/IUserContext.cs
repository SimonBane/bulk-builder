namespace BulkBuilder.Application.Users
{
    public interface IUserContext
    {
        int Id { get; set; }
        string Email { get; set; }
        string Sub { get; set; }
    }
}