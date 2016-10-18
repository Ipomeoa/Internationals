using System;
using SQLite.Net.Attributes;

namespace CatchUp.Core.Models
{
	public class LocalContact
	{
		public LocalContact() { }

			public LocalContact(string email, string firstName, string lastName)
			{
				Email = email;
				FirstName = firstName;
				LastName = lastName;
			}

			[PrimaryKey, AutoIncrement]
			public int Id { get; set; }
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string Email { get; set; }

		}



}

