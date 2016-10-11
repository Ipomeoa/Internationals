using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CatchUp.Core.Models;
using MvvmCross.Core.ViewModels;


namespace CatchUp.Core.ViewModels
{
	public class AddContactViewModel : MvxViewModel
	{
		

		private ObservableCollection<ContactAutoCompleteResult> contacts;

		public ObservableCollection<ContactAutoCompleteResult> Contacts
		{	
			get { return contacts;}
			set { SetProperty(ref contacts, value);}
		}

		private string searchTerm;

		public string SearchTerm 
		{
			get { return searchTerm;}
			set { SetProperty(ref searchTerm, value);
				if (searchTerm.Length > 3)
				{
					SearchContacts(searchTerm);
				}
			}
		}

		public ICommand SelectContactCommand { get; private set;}


		public AddContactViewModel()
		{
			Contacts = new ObservableCollection<ContactAutoCompleteResult>();
		//	SelectContactCommand = MvxCommand<ContactAutoCompleteResult>("CALL FUNCTION => SHOW RESULT LIST");
		}

		//public async void SearchCo...
		public void SearchContacts(string searchTerm)
		{
			//TO DO
			//Call CatchUpIAB330Service
		//	CatchUpIAB330Service catchUpService = new CatchUpIAB330Service();
			Contacts.Clear();
		//	var contactsResults = await catchUpService.GetContacts(searchTerm);
			//var bestContactResults Week 8 prac .3

		//	foreach (var item in contactsResults)
		//	{
		//		Contacts.Add(item);
			//}



		}
	}
}

