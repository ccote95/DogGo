namespace DogGo.Models
{
    public class WalkDog
    {
        public int WalkId { get; set; }
        public Walk? Walk { get; set; }
        public int DogId { get; set; }
        public Dog? Dog { get; set; }
    }
}