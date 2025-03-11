using System;
using System.ComponentModel.DataAnnotations;

namespace Edugo.StudentService.Domain
{
	public abstract class User
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		public string Role { get; set; }
	}
}
