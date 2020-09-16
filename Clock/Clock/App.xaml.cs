using Clock.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Clock
{
    public partial class App : Application
    {
      public  static TimerItemDatabase database;
        public App()
        {
            InitializeComponent();

            Device.SetFlags(new string[] { "Shapes_Experimental" });
            MainPage = new AppShell();
        }

        public static  TimerItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TimerItemDatabase();
                }
                return database;
            }
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
