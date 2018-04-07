using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WugDays2018Demo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleTabbedPage : TabbedPage
    {
        public SimpleTabbedPage ()
        {
            InitializeComponent();
        }
    }
}