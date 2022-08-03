namespace pet_store.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Animal>? Animals { get; set; }
    }
}
