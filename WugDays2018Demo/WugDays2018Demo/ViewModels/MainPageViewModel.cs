using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WugDays2018Demo.Providers;
using Xamarin.Forms;

namespace WugDays2018Demo.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        public MainPageViewModel()
        {
            TextToSpeechNavigationCommand = new Command(async () => await StartListing());

        }

        public async Task StartListing()
        {
            var speechText = await DependencyService.Get<ISpeechToTextProvider>().SpeechToTextAsync();
            FullName = string.IsNullOrEmpty(speechText) ? _fullName : speechText.ToUpper().Replace(" ", "");

        }


        private string _fullName = string.Empty;

        public ICommand TextToSpeechNavigationCommand { get; set; }

        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }


    }
}
