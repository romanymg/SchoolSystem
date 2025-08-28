namespace Common.Models
{
    public class LoginEntity
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
    public class AdminEntity
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public int RoleId { get; set; }
    }
    public class ChangePasswordEntity
    {
        public string? Password { get; set; }
        public string? NewPassword { get; set; }
    }
}
