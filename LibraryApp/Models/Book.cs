namespace LibraryApp.Models
{
    public class Book
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? GenreId { get; set; }   
        public string? Author { get; set; }
        public int? AgeLimit { get; set; }
        public string? ImagePath { get; set; }
        public string? IsAvailable { get; set; }
        public string? IsActive { get; set; }
    }
}
