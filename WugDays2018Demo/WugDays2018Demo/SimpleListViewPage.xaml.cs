using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WugDays2018Demo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleListViewPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public SimpleListViewPage()
        {
            InitializeComponent();
            Items = new ObservableCollection<string>
            {
                "Dobré ráno!",
                "Další přednáška",
            };
			
			MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            if (e.Item == "Dobré ráno!")
            {
                await DisplayAlert("WUGDays", ":)", "OK");
            }
            if (e.Item == "Další přednáška")
            {
                await DisplayAlert("Xamarin", "Již Brzy", "OK");
            }

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
