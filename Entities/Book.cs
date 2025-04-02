namespace LibraryAPI.Entities
{
    public enum GenderTypes
    {
        Romance,
        Horror,
        Fiction,
        Fantasy,
        ScienceFiction,
    }
    public class Book
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Gender { get; set; }
        public float Price { get; set; }
        public int Amount { get; set; }
        
    }
}
