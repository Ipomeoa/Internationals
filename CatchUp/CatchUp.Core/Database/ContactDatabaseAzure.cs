using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatchUp.Core.Interfaces;
using CatchUp.Core.Models;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MvvmCross.Platform;

namespace CatchUp.Core.Database
{
	public class ContactDatabaseAzure : IContactDatabase
	{
		private MobileServiceClient azureDatabase;
		private IMobileServiceSyncTable<Contact> azureSyncTable;
		public ContactDatabaseAzure()
		{
			azureDatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient();
			azureSyncTable = azureDatabase.GetSyncTable<Contact>();
		}

		public async Task<bool> AddContact(string email)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> CheckIfExists(string email)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> CreateContact(string firstName, string lastName, string email)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> DeleteContact(string email)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Contact>> GetAllContacts()
		{
			throw new NotImplementedException();
		}

		public async Task<Contact> GetContact(string email)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Contact>> GetPersonalContacts(string email)
		{
			throw new NotImplementedException();
		}
	}
}

