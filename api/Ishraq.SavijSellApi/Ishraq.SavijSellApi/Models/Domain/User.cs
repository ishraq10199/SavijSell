namespace Ishraq.SavijSellApi.Models.Domain
{
	public class User
	{
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Username { get; set; }
		public string PostalCode { get; set; }
		public bool IsActive { get; set; }
		public bool IsConfirmed { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }

	}
}
