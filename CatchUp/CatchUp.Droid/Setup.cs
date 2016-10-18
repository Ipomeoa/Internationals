using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using CatchUp.Core.Interfaces;
using CatchUp.Droid.Database;
using CatchUp.Core.Database;

namespace CatchUp.Droid
{
	public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new CatchUp.Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

		protected override void InitializeFirstChance()
		{
			Mvx.LazyConstructAndRegisterSingleton<ISqlite, SqliteDroid>();
			//Mvx.LazyConstructAndRegisterSingleton<IDialogService, DialogService>();
			//Mvx.LazyConstructAndRegisterSingleton<IAzureDatabase, AzureDatabase>();

			Mvx.LazyConstructAndRegisterSingleton<IUserStorageDatabase, UserStorageDatabase>();
			//uncomment the below if you only want to use local storage
			//Mvx.LazyConstructAndRegisterSingleton<IContactDatabase, ContactDatabase>();
			base.InitializeFirstChance();
		}

	}
}
