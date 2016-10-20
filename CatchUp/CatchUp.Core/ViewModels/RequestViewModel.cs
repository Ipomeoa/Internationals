using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using CatchUp.Core.Models;
using System.Diagnostics;

// Author: Andreas Andersson n9795383, Marie-Luise Lux n9530801, Samuel Blight n8312885

namespace CatchUp.Core.ViewModels
{
	public class RequestViewModel
		: MvxViewModel
	{
		//Code Samuel

		private string sendReqText = "Send";
		private int count = 0;
		public string SendReqText
		{
			get { return sendReqText; }
			set
			{
				count++;
				sendReqText = value + count;
				RaisePropertyChanged(() => SendReqText);
			}
		}
		//End of Samuel's Code.

		//Samuel's Code
		public ICommand BtnSendReqCommand { get; private set; }
		//End of Samuel's Code
		public RequestViewModel()
		{
			//Samuel's Codee
			BtnSendReqCommand = new MvxCommand(() =>
			{
				SendReqText = "Message Sent!";
			});
			//End of Samuel's Code
		}

		public RequestViewModel(LocalContact contact)
		{
			//Use the contact.
			if (contact != null)
			{
				Debug.WriteLine("Contact-Email:" + contact.EmailContact);
			}
			//Samuel's Codee
			BtnSendReqCommand = new MvxCommand(() =>
			{
				SendReqText = "Message Sent!";
			});
			//End of Samuel's Code
		}
	}
}

