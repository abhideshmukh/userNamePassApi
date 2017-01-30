using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;

namespace userNamePassApi
{
   
    public partial class Page1 : ContentPage
    {
        string UserName;
        string Passw;
        string result;
 // String BaseUrl="Your Url &username="
 //String PassUrl="remaining url &password="
        public Page1()
        {
            InitializeComponent();
            btn.Clicked += async (s, e) =>
            {

                
               
                UserName = usrName.Text;
                Passw = pass.Text;                
                var result = await GetData(UserName, Passw);
                if(result)
                {
               
                    userNamePassApi.Utils.Settings.GeneralSettings = result.ToString();
                    userNamePassApi.App.Current.MainPage = new NavigationPage(new LoggedInPage());
                    
                }
                else
                {
                    DisplayAlert("error", "asd", "OK");
                }
            };

        }


       

        public string EmailAddress
        {
            get
            {
                return result;
            }
            set
            {
                result=value;
                userNamePassApi.Utils.Settings.GeneralSettings = value;
            }
        }





        private async  Task<bool> GetData(string UserName,string Passw)
        {

            string urls = baseUrl + UserName + bUrl + Passw;
            HttpClient webClient = new HttpClient();
            string aaa = await webClient.GetStringAsync(urls);
            
            
            var jObj = JsonConvert.DeserializeObject<RootObject>(aaa);
            string asd = jObj.data;
            if (asd == "Logged In")
            {
                return true;
            }
                return false;


        }
    }
}
