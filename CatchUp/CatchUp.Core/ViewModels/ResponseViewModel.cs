using MvvmCross.Core.ViewModels;
using System.Windows.Input;

// Author: Andreas Andersson n9795383, Marie-Luise Lux n9530801, Samuel Blight n8312885

namespace CatchUp.Core.ViewModels
{
	public class ResponseViewModel
		: MvxViewModel
	{
		//Code Marie

		private string responseText = "This is a example Text. If you press the \"send\" button it will change.";
		public string ResponseText
		{
			get { return responseText; }
			set
			{
				if (value != null && value != responseText)
				{
					responseText = "You have just clicked the send button.";
					RaisePropertyChanged(() => ResponseText);
				}
			}
		}
		//End of Marie's Code.
		//Marie Code
		public ICommand SendResponse { get; private set; }
		//End of Marie's Code
		public ResponseViewModel()
		{
			//Marie Code
			SendResponse = new MvxCommand(() =>
			{
				ResponseText = "Save Button was pressed!";
			});
			//End of Marie's Code
		}
	}
}

