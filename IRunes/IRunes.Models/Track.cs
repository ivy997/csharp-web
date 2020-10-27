namespace IRunes.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Track
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Link { get; set; }

		[Required]
		public decimal Price { get; set; }
	}
}
