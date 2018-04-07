using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WugDays2018Demo.Interface;
using Xamarin.Forms;

namespace WugDays2018Demo.Controls
{
	public class ImageEntry : Entry, IEditTextController
	{

		public static readonly BindableProperty TappedCommandProperty = BindableProperty.Create("TappedCommand", typeof(ICommand), typeof(ImageEntry), null);


		public void ItemTapped()
		{
			TappedCommand.Execute(null);
		}

		public ICommand TappedCommand
		{
			get
			{
				return (ICommand)GetValue(TappedCommandProperty);
			}
			set
			{
				SetValue(TappedCommandProperty, value);
			}
		}


	}
}
