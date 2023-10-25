using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using DynamicData.Binding;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using Data;

namespace App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
		string? _title;
		ViewModelBase? _content;

        public MainWindowViewModel()
		{
			TrackHabit();
		}

		public string? Title
		{
			get => _title;
			set => this.RaiseAndSetIfChanged(ref _title, value);
		}

		public ViewModelBase? Content
		{
			get => _content;
			set => this.RaiseAndSetIfChanged(ref _content, value);
		}

		public void SetHabit()
		{
			var vm = new HabitSettingViewModel();
			
			vm.StartTracking.Take(1).Subscribe(model =>
			{
				using (var context = new HabitDbContext())
				{
					context.Habits.Add(model);
					context.HabitChecks.AddRange(
						Enumerable.Range(0, vm.Duration)
						.Select(offset => new HabitCheck
						{
							Date = vm.StartDate.AddDays(offset),
							Habit = model,
							IsChecked = false
						})
						.ToList());
					context.SaveChanges();
				}
				TrackHabit();
			});
			
			Title = "Set new habit to track";
			Content = vm;
		}

		public void TrackHabit()
		{
			using (var context = new HabitDbContext())
			{
				var habit = context.Habits
					.Include(x => x.HabitChecks)
					.FirstOrDefault(x => !x.IsFinished);

				if (habit == null)
				{
					SetHabit();
					return;
				}

				var vm = new HabitTrackingViewModel(habit.HabitChecks.OrderBy(x => x.Date));
				vm.WhenPropertyChanged(x => x.IsFinished, false).Subscribe(FinishHabit);
				
				Title = habit.Title;
				Content = vm;
			}
		}

		public void FinishHabit(PropertyValue<HabitTrackingViewModel, bool> obj)
		{
			if (obj.Sender.IsFinished)
			{
				using (var context = new HabitDbContext())
				{
					var habit = context.Habits
						.Include(x => x.HabitChecks)
						.FirstOrDefault(x => !x.IsFinished);

					habit.IsFinished = true;
					context.Habits.Update(habit);
					context.SaveChanges();

					var vm = new CongratulationsViewModel(habit);
					Title = habit.Title;
					Content = vm;
				}
			}
		}
	}
}
