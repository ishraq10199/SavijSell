namespace Ishraq.SavijSellApi.Models.Api
{
    public class Product
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
		public string Location { get; set; }
        public decimal Price{ get; set; }
        public DateTime CreatedDate { get; set; }
	}
}
