using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WugDays2018Demo.ViewModels;
using Xamarin.Forms;

namespace WugDays2018Demo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            BindingContext = new MainPageViewModel();

		}
    }
}
