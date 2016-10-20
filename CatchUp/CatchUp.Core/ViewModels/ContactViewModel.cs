using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using CatchUp.Core.Interfaces;
using System.Collections.ObjectModel;
using CatchUp.Core.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;

// Author: Andreas Andersson n9795383, Marie-Luise Lux n9530801, Samuel Blight n8312885

namespace CatchUp.Core.ViewModels
{
	public class ContactViewModel
		: MvxViewModel
	{
		private ILocalContactDatabase dblocal;

		private string emailContact;
		public string EmailContact
		{
			get { return emailContact; }
			set
			{
				if (value != null)
				{
					SetProperty(ref emailContact, value);
				}
			}
		}
		private string firstNameContact;
		public string FirstNameContact
		{
			get { return firstNameContact; }
			set
			{
				if (value != null)
				{
					SetProperty(ref firstNameContact, value);
				}
			}
		}
		private string lastNameContact;
		public string LastNameContact
		{
			get { return lastNameContact; }
			set
			{
				if (value != null)
				{
					SetProperty(ref lastNameContact, value);
				}
			}
		}
		private string emailRequest;
		public string EmailRequest
		{
			get { return emailRequest; }
			set
			{
				if (value != null)
				{
					SetProperty(ref emailRequest, value);
				}
			}
		}

		private string firstNameRequest;
		public string FirstNameRequest
		{
			get { return firstNameRequest; }
			set
			{
				if (value != null)
				{
					SetProperty(ref firstNameRequest, value);
				}
			}
		}
		private string lastNameRequest;
		public string LastNameRequest
		{
			get { return lastNameRequest; }
			set
			{
				if (value != null)
				{
					SetProperty(ref lastNameRequest, value);
				}
			}
		}
			
		//ContactList
		private ObservableCollection<LocalContact> contactItems;
		public ObservableCollection<LocalContact> ContactItems
		{
			get { return contactItems; }
			set { SetProperty(ref contactItems, value); }

		}

		//RequestList
		private ObservableCollection<Contact> requestItems;
		public ObservableCollection<Contact> RequestItems
		{
			get { return requestItems; }
			set { SetProperty(ref requestItems, value); }

		}


		public ICommand BtnAddContactCommand { get; private set; }
		public ICommand BtnApproveRequestCommand { get; private set; }
		public ICommand BtnDenyRequestCommand { get; private set; }
		public ICommand SelectContactCommand { get; private set; }
		public ICommand SelectRequestCommand { get; private set; }
		public ICommand BtnSendMsgCommand { get; private set; }
		public ContactViewModel(ILocalContactDatabase dblocal)
		{
			this.dblocal = dblocal;
			ContactItems = new ObservableCollection<LocalContact>();
			RequestItems = new ObservableCollection<Contact>();
			//dblocal.CreateLocalContact("Rand3@rand.com", "RandFirs3", "RandLast3");

			//Add contacts to list from db
			IEnumerable<LocalContact> dbContactList = dblocal.GetLocalContacts().Result;
			foreach (var contact in dbContactList)
			{
				ContactItems.Add(contact);
				RaisePropertyChanged(() => ContactItems);
				Debug.WriteLine("Contact:" + contact.EmailContact + ", " + contact.FirstNameContact + ", " + contact.LastNameContact);
			}

			//Load database and append to list
			//ContactList.Add(contact); for every contact form DB
			//RequestList.Add(request); for every request in DB

			BtnAddContactCommand = new MvxCommand(() =>
		   {
			   ShowViewModel<AddContactViewModel>();
		   });

			//Selected listItem"button"
			SelectContactCommand = new MvxCommand<LocalContact>(contact =>
			{
				//Do something with your listitem
				//EmailContact = contact.EmailContact;
				//FirstNameContact = contact.FirstNameContact;
				//LastNameContact = contact.LastNameContact;

			//	LocalContact tempContact = contact;
				Debug.WriteLine("SelectContactCommand" );
			});

			//Button for write to-> and call request page with that parameter. 
			//add a "Write icon" and listen to it. 

			BtnSendMsgCommand = new MvxCommand(() =>
		   		{
					   // Debug.WriteLine("SendMSgCommand" + tempContact.EmailContact);
					   //  ShowViewModel<RequestViewModel>(tempContact);
					   ShowViewModel<RequestViewModel>();
		  		 });

			//Selected listItem"button"	Change to <LocalContact> or RequestContact?
			SelectRequestCommand = new MvxCommand<Contact>(contact =>
			{
				EmailRequest = contact.Email;
				FirstNameRequest = contact.FirstName;
				LastNameRequest = contact.LastName;

				var tempEmail = contact.Email;
				var tempFirstname = contact.FirstName;
				var tempLastname = contact.LastName;
				//Use the buttons nested?

				//Do something with your listitem
				//UnitCode = unit.UnitCode;
				//UnitName = unit.UnitName;
			});
			BtnApproveRequestCommand = new MvxCommand(() =>
		   {
			  // Debug.WriteLine("Approve -SelectRequestCommand-Email:" + tempEmail);
			   //Save to local storage, Append to contact list, Delete request from AzureService.
		   });
			BtnDenyRequestCommand = new MvxCommand(() =>
		   {
				   //delete request from requestlist and AzureService.
			//	   Debug.WriteLine("Deny- SelectRequestCommand-Email:" + tempEmail);
		   });
		}
	}
}

