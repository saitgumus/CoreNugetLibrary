namespace SG.Kernel.Types
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string LoginFailCount { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}