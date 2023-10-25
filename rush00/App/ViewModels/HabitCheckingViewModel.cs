using System;
using System.Reactive;
using ReactiveUI;
using Data.Models;

namespace App.ViewModels
{
	public class HabitCheckingViewModel : ViewModelBase
	{
		bool _isChecked;

		public HabitCheckingViewModel(HabitCheck habitCheck)
		{
			IsChecked = habitCheck.IsChecked;
			Date = habitCheck.Date;
			HabitCheck = habitCheck;
		}

		public bool IsChecked
		{
			get => _isChecked;
			set => this.RaiseAndSetIfChanged(ref _isChecked, value);
		}

		public DateTimeOffset Date { get; }

		public HabitCheck HabitCheck { get; }
	}
}
