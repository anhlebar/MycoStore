namespace MycoStore.Shared
{
    public class MushroomProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public MushroomUse Use { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public ProductType Type { get; set; }  // ✅ Add this line
    }

    public enum MushroomUse
    {
        Medicinal,
        Edible
    }

    public enum ProductType
    {
        Culture,
        GrowBox,
        DryMushroom,
        TinctureExtract
    }
}
