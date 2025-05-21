namespace MycoStore.Shared
{
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

    public class MushroomProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = "";
        public ProductType Type { get; set; }
        public MushroomUse Use { get; set; }
    }
}
