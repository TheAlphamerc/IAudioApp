using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IAudio
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void Submit_Click(object sender, EventArgs e)
        {
            var eml = _emailid.Text;
            var pas = _password.Text;

            var emlregx = "^[A-Za-z0-9]([_A-Z-a-z0-9.!#$%&'*+-=?^`{|}~\\/]{2,20})*@([[A-Za-z]{1,15})\\.([a-z]{2,15})$";
            var pssregs = "^.*(?=.{8,})(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$";

            if (Regex.IsMatch(eml, emlregx))
            {
                if (Regex.IsMatch(pas, pssregs))
                {
                    if (pas.Length < 17)
                        await Navigation.PushAsync(new Views.LangAudio());
                   else
                        await DisplayAlert("Alert","Password can not be greater than 16", "Ok");
                    //NavigationPage(new Views.SignUp());
                }
                else if (pas.Length == 0)
                {
                    await DisplayAlert("Alert", " Password field can not be leaved empty", "Ok");
                }

                else 
                {
                    await DisplayAlert("Alert", "Invalid Paasword try again ", "Ok");
                }
            }
            else if (eml.Length == 0 && pas.Length == 0)
            {
                await DisplayAlert("Alert", " Email id and password field can not be leaved empty", "Ok");
            }
            else if (Regex.IsMatch(eml, emlregx) == false && eml.Length > 0)
            {
                await DisplayAlert("Alert", "Invalid  Email id format, email id should contain at least one @ and . symbol", "Ok");
            }
            else if (eml.Length == 0 )
            {
                await DisplayAlert("Alert", " Email id field can not be leaved empty", "Ok");
            }
            else
            {
                await DisplayAlert("Alert", "Please provide valid entry to fields", "Ok");


            }
        }
    }
}
