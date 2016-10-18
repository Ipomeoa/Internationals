using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

		public async Task<bool> AddContact(Contact contact)
		{
			await SyncAsync(true);
			await azureSyncTable.InsertAsync(contact);
			await SyncAsync();

			//Check that the contact's added. 
			if (CheckIfExists(contact.Email).Result)
			{
				return true;
			}
			return false;
		}

		public async Task<bool> CheckIfExists(string email)
		{
			
			await SyncAsync(true);
			var locations = await azureSyncTable.Where(x => x.Email == email ).ToListAsync();
			return locations.Any();

		}

		public async Task<bool> CreateContact(string firstName, string lastName, string email)
		{
			Contact contact = new Contact(firstName, lastName, email);

			await SyncAsync(true);
			await azureSyncTable.InsertAsync(contact);
			await SyncAsync();

			//Check that the contact's created. 
			if (CheckIfExists(email).Result)
			{
				return true;
			}
			return false;
		}



		public async Task<bool> DeleteContact(string email)
		{
			await SyncAsync(true);
			var contact = await azureSyncTable.Where(x => x.Email == (string)email).ToListAsync();
			if (contact.Any())
			{
				await azureSyncTable.DeleteAsync(contact.FirstOrDefault());
				await SyncAsync();
			}
			//Check that the contact's deleted. 
			if (!CheckIfExists(email).Result)
			{
				return true;
			}
			return false;
		}



		public async Task<IEnumerable<Contact>> GetAllContacts()
		{
			await SyncAsync(true);
			var contacts = await azureSyncTable.ToListAsync();
			return contacts;
		}

		public async Task<Contact> GetContact(string email)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Contact>> GetPersonalContacts(string email)
		{
			await SyncAsync(true);
			var contacts = await azureSyncTable.ToListAsync();
			return contacts;
		}



		private async Task SyncAsync(bool pullData = false)
		{
			try
			{
				await azureDatabase.SyncContext.PushAsync();

				if (pullData)
				{
					await azureSyncTable.PullAsync("allContacts", azureSyncTable.CreateQuery()); // query ID is used for incremental sync
				}
			}

			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
		}
	}
}

