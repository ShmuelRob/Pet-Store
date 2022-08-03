namespace pet_store.Models
{
    public class Animal
    {
        public string? AnimalID { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? PictureSrc { get; set; }
        public Category? Category { get; set; }
        public IEnumerable<Comment>? Comments { get; set; }
    }
}
