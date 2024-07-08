namespace DogGo.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public String Breed { get; set; }
        public string? Notes { get; set; }
        public string? ImageUrl { get; set; }
        public Owner DogOwner { get; set; }
    }
}