namespace LibraryApp.Models
{
    public class Account
    {
        public int? Id { get; set; }
        public int LoginId { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public byte[]? Salt { get; set; }
        public int? Role { get; set; }
        public string? ImagePath { get; set; }
    }
}