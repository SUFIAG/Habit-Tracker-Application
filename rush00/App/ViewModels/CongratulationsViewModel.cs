using System;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using Data.Models;

namespace App.ViewModels
{
	public class CongratulationsViewModel : ViewModelBase
	{
		int checkedDays;
		int totalDays;

		public CongratulationsViewModel(Habit habit)
		{
			checkedDays = habit.HabitChecks.Where(x => x.IsChecked).Count();
			totalDays = habit.HabitChecks.Count();
			DaysRatio = $"{checkedDays}/{totalDays} days checked.";
			FinalOutcome = "Finally: " + habit.Motivation;
		}

		public string DaysRatio { get; }

		public string FinalOutcome { get; }
	}
}
