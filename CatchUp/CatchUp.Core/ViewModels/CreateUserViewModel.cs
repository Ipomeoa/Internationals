using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using CatchUp.Core.Interfaces;
using CatchUp.Core.Database;
using System.Diagnostics;

// Author: Andreas Andersson n9795383, Marie-Luise Lux n9530801, Samuel Blight n8312885

namespace CatchUp.Core.ViewModels
{
	public class CreateUserViewModel
		: MvxViewModel
	{

		private IUserStorageDatabase db;

		private string firstname = "";
		public string Firstname
		{
			get { return firstname; }
			set
			{
				if (value != null && value != firstname)
				{
					firstname = value;
				}
			}
		}

		private string lastname = "";
		public string Lastname
		{
			get { return lastname; }
			set
			{
				if (value != null && value != lastname)
				{
					lastname = value;
				}
			}
		}


		private string email = "";
		public string Email
		{
			get { return email; }
			set
			{
				if (value != null && value != email)
				{
					email = value;
				}
			}
		}


		public ICommand BtnUserCommand { get; private set; }





			
		public CreateUserViewModel(IUserStorageDatabase db)
		{
			this.db = db;
			Debug.WriteLine("Test:" );

			BtnUserCommand = new MvxCommand(async () =>
		   {
			   Debug.WriteLine("Test2:");
			   //Create new user with all variables. 
				await db.CreateUser(Email, Firstname, Lastname);
			   Debug.WriteLine("User created with email:" + email);
			   ShowViewModel<HomeViewModel>();
		   });
		}
	}
}

