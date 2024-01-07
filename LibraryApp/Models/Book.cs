namespace LibraryApp.Models
{
    public class Book
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public int? GenreId { get; set; }   
        public string? Author { get; set; }
        public int? AgeLimit { get; set; }
        public string? ImagePath { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsActive { get; set; }
    }
}
