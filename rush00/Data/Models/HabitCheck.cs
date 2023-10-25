using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
	public class HabitCheck
	{
		[Key, Required]
		public int Id { get; set; }
		[Required]
		public DateTimeOffset Date { get; set; }
		[Required]
		public bool IsChecked { get; set; } = false;

		public int HabitId { get; set; }
		public Habit Habit { get; set; }
	}
}
