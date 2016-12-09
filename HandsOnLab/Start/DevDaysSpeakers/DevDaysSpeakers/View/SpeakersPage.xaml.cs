using Xamarin.Forms;
using DevDaysSpeakers.ViewModel;
using System;

namespace DevDaysSpeakers.View
{
	public partial class SpeakersPage : ContentPage
	{
		SpeakersViewModel vm;
		public SpeakersPage()
		{
			InitializeComponent();

			//Create the view model and set as binding context
			vm = new SpeakersViewModel();
			BindingContext = vm;
			ListViewSpeakers.ItemSelected += ListViewSpeakers_ItemSelected;
		}

		void ListViewSpeakers_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			throw new NotImplementedException();
		}
}
}
