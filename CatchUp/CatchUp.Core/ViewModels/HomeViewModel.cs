using MvvmCross.Core.ViewModels;
using System.Windows.Input;

// Author: Andreas Andersson n9795383, Marie-Luise Lux n9530801, Samuel Blight n8312885

namespace CatchUp.Core.ViewModels
{
	public class HomeViewModel
		: MvxViewModel
	{

		public ICommand BtnNotificationCommand { get; private set; }
		public ICommand BtnOptionCommand { get; private set; }
		public ICommand BtnRequestCommand { get; private set; }
		public ICommand BtnContactCommand { get; private set; }

		public HomeViewModel()
		{
			BtnNotificationCommand = new MvxCommand(() =>
		   {
				ShowViewModel<NotificationViewModel>();
		   });
			BtnOptionCommand = new MvxCommand(() =>
		   {
			  ShowViewModel<OptionsViewModel>();
		   });
			BtnRequestCommand = new MvxCommand(() =>
		   {
			  ShowViewModel<RequestViewModel>();
		   });
			BtnContactCommand = new MvxCommand(() =>
		   {
			  ShowViewModel<ContactViewModel>();
		   });
		}
	}
}

