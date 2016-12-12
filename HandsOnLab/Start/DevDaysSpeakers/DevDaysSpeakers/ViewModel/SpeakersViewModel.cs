using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DevDaysSpeakers.Model;
using DevDaysSpeakers.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace DevDaysSpeakers.ViewModel
{
	public class SpeakersViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private bool busy;

		public bool IsBusy
		{
			get { return busy; }
			set
			{
				busy = value;
				OnPropertyChanged();
				GetSpeakersCommand.ChangeCanExecute();
			}
		}

		public SpeakersViewModel()
		{
			Speakers = new ObservableCollection<Speaker>();
			GetSpeakersCommand = new Command(
				async () => await GetSpeakers(),
				() => !IsBusy);
		}

		public ObservableCollection<Speaker> Speakers { get; set; }
		public Command GetSpeakersCommand { get; set; }

		private void OnPropertyChanged([CallerMemberName] string name = null) =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

		private async Task GetSpeakers()
		{
			if (IsBusy)
				return;

			Exception error = null;


			try
			{
				IsBusy = true;

				var service = DependencyService.Get<AzureService>();
				var items = await service.GetSpeakers();


					//Load speakers into list
					Speakers.Clear();
					foreach (var item in items)
						Speakers.Add(item);
				
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Error: " + ex);
				error = ex;
			}
			finally
			{
				IsBusy = false;
			}

			if (error != null)
				await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");
		}
	}
}
