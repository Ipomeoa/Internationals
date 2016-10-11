using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatchUp.Core.Interfaces;
using CatchUp.Core.Models;
using Microsoft.WindowsAzure.MobileServices;
using MvvmCross.Platform;
using SQLite.Net;

namespace CatchUp.Core.Database
{
	public class ContactDatabase : IContactDatabase
	{
		private SQLiteConnection database;
		public ContactDatabase()
		{
			var sqlite = Mvx.Resolve<ISqlite>();
			database = sqlite.GetConnection();
			database.CreateTable<Contact>();
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



		public async MobileServiceClient GetMobileServiceClient()
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Contact>> GetPersonalContacts(string email)
		{
			throw new NotImplementedException();
		}




	}
}

