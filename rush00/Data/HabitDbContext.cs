using System;
using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace Data
{
	public class HabitDbContext : DbContext
	{
		public DbSet<Habit> Habits { get; set; }
		public DbSet<HabitCheck> HabitChecks { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Filename=habits.db");
		}
	}
}
