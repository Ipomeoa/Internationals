using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using CatchUp.Core.Database;
using System.Collections.ObjectModel;
using CatchUp.Core.Interfaces;
using CatchUp.Core.Models;

// Author: Andreas Andersson n9795383, Marie-Luise Lux n9530801, Samuel Blight n8312885

namespace CatchUp.Core.ViewModels
{
	public class LoginViewModel
		: MvxViewModel
	{
		private  IContactDatabase contactDatabase;
		private LocalVars vars = new LocalVars();

		private ObservableCollection<ContactAutoCompleteResult> contacts;

		public ObservableCollection<ContactAutoCompleteResult> Contacts
		{
			get { return contacts; }
			set { SetProperty(ref contacts, value); }
		}

		private string searchTerm;

		public string SearchTerm
		{
			get { return searchTerm; }
			set
			{
				SetProperty(ref searchTerm, value);
				if (searchTerm.Length > 3)
				{
					SearchEmail(searchTerm);
				}
			}
		}

		public async void Selectcontact(ContactAutoCompleteResult selectedcontact)
		{

			if (!await contactDatabase.CheckIfExists(selectedcontact.Email))
			{
				vars.SetEmail(selectedcontact.Email);

				Close(this);
			}

		}

		public async void SearchEmail(string searchTerm)
		{
			ContactDatabase db = new ContactDatabase();
			contacts.Clear();   //Clear result list
								//var contactResults = await db.GetContact(searchTerm);
			var contactResults = await db.GetContact(searchTerm);


			{
			//	contacts.Add(contactResults);
			}
		}

		public ICommand SelectcontactCommand { get; private set; }


		public ICommand BtnCreateUserCommand { get; private set; }
		public ICommand BtnDontLoginCommand { get; private set; }



		public LoginViewModel(IContactDatabase contactDatabase)
		{

			this.contactDatabase = contactDatabase;
			contacts = new ObservableCollection<ContactAutoCompleteResult>();
			SelectcontactCommand = new MvxCommand<ContactAutoCompleteResult>(selectedcontact =>
			{
				Selectcontact(selectedcontact);
			});
			//Implement searchfunction

			//Implement listitems

			BtnCreateUserCommand = new MvxCommand(() =>
		   {
				ShowViewModel<CreateUserViewModel>();
		   });

			BtnDontLoginCommand = new MvxCommand(() =>
		   {
			   ShowViewModel<HomeViewModel>();
		   });
		}


	}
}

