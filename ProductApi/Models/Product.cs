using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models
{
	public class Product
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Name is Required.")]
		public string Name { get; set; } = string.Empty;

		[Range(0.01, 10000, ErrorMessage = "Price must be positive.")]
		public decimal Price { get; set; }
	}
}
