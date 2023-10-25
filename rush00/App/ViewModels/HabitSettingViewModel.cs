using System;
using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using Data.Models;

namespace App.ViewModels
{
	public class HabitSettingViewModel : ViewModelBase
	{
		string _title;
		string _motivation;
		DateTimeOffset _startDate;
		int _duration;
		
		public HabitSettingViewModel()
		{
			_title = "";
			_motivation = "";
			_startDate = DateTimeOffset.Now;
			_duration = 0;

			IObservable<bool> canStart = this.WhenAnyValue(
				x => x.Title, x => x.Motivation, x => x.Duration,
				(x, y, z) =>
				!string.IsNullOrWhiteSpace(x) &&
				!string.IsNullOrWhiteSpace(y) &&
				z > 0);
			
			StartTracking = ReactiveCommand.Create(() => new Habit
			{
				Title = Title.Trim(),
				Motivation = Motivation.Trim(),
				HabitChecks = new List<HabitCheck>(),
				IsFinished = false
			}, canStart);
		}

		public string Title
		{
			get => _title;
			set => this.RaiseAndSetIfChanged(ref _title, value);
		}

		public string Motivation
		{
			get => _motivation;
			set => this.RaiseAndSetIfChanged(ref _motivation, value);
		}

		public DateTimeOffset StartDate
		{
			get => _startDate;
			set => this.RaiseAndSetIfChanged(ref _startDate, value);
		}

		public int Duration
		{
			get => _duration;
			set => this.RaiseAndSetIfChanged(ref _duration, value);
		}

		public ReactiveCommand<Unit, Habit > StartTracking { get; }
	}
}
