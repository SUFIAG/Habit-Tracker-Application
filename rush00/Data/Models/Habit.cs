using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
	public class Habit
	{
		[Key, Required]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public string Motivation { get; set; }
		[Required]
		public bool IsFinished { get; set; } = false;
		
		public List<HabitCheck> HabitChecks { get; set; }
	}
}
