namespace DogGo.Models
{
    public class Walk
    {
        public int Id { get; set; }
        public int DogId { get; set; }
        public Dog Dog { get; set; }
        public int WalkerId { get; set; }
        public Walker Walker { get; set; }
        public int Duration { get; set; }
    }
}