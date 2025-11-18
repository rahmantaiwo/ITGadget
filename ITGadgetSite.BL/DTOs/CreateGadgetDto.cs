namespace ITGadgetSite.BL.DTOs
{
    public class CreateGadgetDto
    {
        public string GadgetName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
