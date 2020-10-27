namespace IRunes.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Album
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Cover { get; set; }

		[Required]
		public decimal Price { get; set; }

		public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
	}
}
