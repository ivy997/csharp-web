namespace IRunes.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class User
	{
		//GuID
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }

		[Required]
		//Validate
		public string Username { get; set; }

		//Encoded in database
		[Required]
		//Validate
		public string Password { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}
