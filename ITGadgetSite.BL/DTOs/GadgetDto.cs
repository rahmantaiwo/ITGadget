namespace ITGadgetSite.BL.DTOs
{
    public class GadgetDto
    {
        public Guid Id { get; set; }
        public string GadgetName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
