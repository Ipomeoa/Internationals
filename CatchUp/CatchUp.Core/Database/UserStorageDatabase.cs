using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CatchUp.Core.Interfaces;
using MvvmCross.Platform;
using SQLite.Net;

namespace CatchUp.Core.Database
{
	
public class UserStorageDatabase : IUserStorageDatabase
		{
			private SQLiteConnection database;
			
			public UserStorageDatabase()
			{
				var sqlite = Mvx.Resolve<ISqlite>();
				database = sqlite.GetConnection();
				database.CreateTable<UserStorage>();
			}

		public async Task<int> CreateUser(string email, string firstname, string lastname)
		{
			UserStorage userStorage = new UserStorage(email, firstname, lastname);
			var num = database.Insert(userStorage);
			//database.ExecuteScalar<UserStorage>("INSERT INTO UserStorage(Email,FirstName,LastName,AutoMessage)" +
			//                                    "VALUES ("+email+","+firstname+","+lastname+"," +
			 //                                   "Sorry but i am busy right now) ");
			database.Commit();

			return num;
		}

		public async Task<string> GetAutoMessage()
		{
			var str= database.ExecuteScalar<UserStorage>("SELECT * FROM UserStorage");
			return str.AutoMessage;
		}

		public async Task<string> GetEmail()
		{
			var str = database.ExecuteScalar<UserStorage>("SELECT * FROM UserStorage");
			return str.Email;
		}

		public async Task<string> GetFirstName()
		{
			var str = database.ExecuteScalar<UserStorage>("SELECT * FROM UserStorage");
			return str.FirstName;
		}

		public async Task<string> GetLastName()
		{
			var str = database.ExecuteScalar<UserStorage>("SELECT * FROM UserStorage");
			return str.LastName;
		}

		public async Task<bool> GetMode()
		{
			var str = database.ExecuteScalar<UserStorage>("SELECT * FROM UserStorage");
			return str.Mode;
		}

		public async Task<bool> GetSound()
		{
			var str = database.ExecuteScalar<UserStorage>("SELECT * FROM UserStorage");
			return str.Sound;
		}

		public async Task<bool> GetVibration()
		{
			var str = database.ExecuteScalar<UserStorage>("SELECT * FROM UserStorage");
			return str.Vibration;
		}

		public async Task<bool> UpdateAutoMessage(string message)
		{
			var email = GetEmail();
			database.ExecuteScalar<UserStorage>("UPDATE UserStorage SET AutoMessage='"+message+"' WHERE" +
			                                    "Email='"+email+"'");
			database.Commit();
			var comp = GetAutoMessage();
			return comp.Result == message;
		}

		public async Task<bool> UpdateEmail(string email)
		{
			var oldEmail = GetEmail();
			database.ExecuteScalar<UserStorage>("UPDATE UserStorage SET Email='" + email + "' WHERE" +
												"Email='" + oldEmail + "'");
			database.Commit();
			var newEmail = GetEmail();
			return newEmail.Result == email;
		}

		public async Task<bool> UpdateFirstName(string firstname)
		{
			var email = GetEmail();
			database.ExecuteScalar<UserStorage>("UPDATE UserStorage SET FirstName='" + firstname + "' WHERE" +
												"Email='" + email + "'");
			database.Commit();
			var comp = GetFirstName();
			return comp.Result == firstname;
		}

		public async Task<bool> UpdateLastName(string lastname)
		{
			var email = GetEmail();
			database.ExecuteScalar<UserStorage>("UPDATE UserStorage SET FirstName='" + lastname + "' WHERE" +
												"Email='" + email + "'");
			database.Commit();
			var comp = GetLastName();
			return comp.Result == lastname;
		}

		public async Task<bool> UpdateMode(bool mode)
		{
			var email = GetEmail();
			database.ExecuteScalar<UserStorage>("UPDATE UserStorage SET Mode='" + mode + "' WHERE" +
												"Email='" + email + "'");
			database.Commit();
			var comp = GetMode();
			return comp.Result == mode;
		}

		public async Task<bool> UpdateSound(bool sound)
		{
			var email = GetEmail();
			database.ExecuteScalar<UserStorage>("UPDATE UserStorage SET Sound='" + sound + "' WHERE" +
												"Email='" + email + "'");
			database.Commit();
			var comp = GetSound();
			return comp.Result == sound;
		}

		public async Task<bool> UpdateVibration(bool vibration)
		{
			var email = GetEmail();
			database.ExecuteScalar<UserStorage>("UPDATE UserStorage SET Vibration='" + vibration + "' WHERE" +
												"Email='" + email + "'");
			database.Commit();
			var comp = GetVibration();
			return comp.Result == vibration;
		}

		public async Task<bool> UserExists()
		{
			var value = database.Table<UserStorage>().Any();
			var values = database.Table<UserStorage>().ToList();
			return value;

		}
	}
}

