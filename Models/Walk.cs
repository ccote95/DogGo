using System.ComponentModel.DataAnnotations.Schema;

namespace DogGo.Models
{
    public class Walk
    {
        public int Id { get; set; }
        public List<WalkDog>? WalkDogs { get; set; }
        [NotMapped]
        public List<int>? SelectedDogIds { get; set; } = new List<int>();
        public int WalkerId { get; set; }
        public Walker? Walker { get; set; }
        public int Duration { get; set; }
    }
}