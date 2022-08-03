namespace pet_store.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string? Content { get; set; }
        public int AnimalID { get; set; }
        public Animal? AnimalCommented { get; set; }
    }
}
