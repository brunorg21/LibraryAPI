using LibraryAPI.Entities;

namespace LibraryAPI.Controllers.Communication.Requests
{
    public class RequestCreateUserJson
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Gender { get; set; }
        public float Price { get; set; }
        public int Amount { get; set; }
    }
}
