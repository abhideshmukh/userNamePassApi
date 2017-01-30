using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace userNamePassApi
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            string result = userNamePassApi.Utils.Settings.GeneralSettings;
            if (result == "True")
            {
                MainPage = new NavigationPage(new LoggedInPage());


                Device.StartTimer(new TimeSpan(0, 0, 0, 20, 0), () => {
                    userNamePassApi.App.Current.MainPage = new NavigationPage(new Page1());

                    return true;
                });


            }
            else
            {
                MainPage = new NavigationPage(new Page1());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
