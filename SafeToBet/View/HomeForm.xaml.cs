using System;
using SafeToBet.ViewModel;
using SafeToBet.Classes;
using Xamarin.Forms;

namespace SafeToBet
{
    public partial class HomeForm : ContentPage
    {
        //private String strPhoneNumber;
        //private String strName;


        String strBetName;
        //String strBetDate;
        //String strBetType;
        String strBetDescription;
        String strBetOpponent;
        //String strBetAmount;

        public HomeForm()
        {
            InitializeComponent();
            strBetName = BetSharedPreference.GetBetName;
            //strBetDate = BetSharedPreference.GetBetDateStart;
            //strBetType = BetSharedPreference.GetType;
            strBetDescription = BetSharedPreference.GetBetDescription;
            strBetOpponent = BetSharedPreference.GetBetOpponenet;
            //strBetAmount = BetSharedPreference.GetAmount;

            labelBetName.Text = "Name: " + strBetName;
            //labelBetDate.Text = "Date Start: " + strBetDate;
            //labelBetType.Text = "Type: " + strBetType;
            labelBetDescription.Text = "Description: " + strBetDescription;
            labelBetOpponent.Text = "Opponent: " + strBetOpponent;
            //labelBetAmount.Text = "Amount: " + strBetAmount;

            String LoggedIn = SharedPreference.GetLoginStatus;
            //strPhoneNumber = SharedPreference.GetPhoneNumber;

            if (LoggedIn.Equals("false"))
            {
                startLoginScreen();
            }
        }
        async private void startLoginScreen()
        {
            await Navigation.PushModalAsync(new LoginForm());
        }
        async void showDisplayAlert(String strMessage)
        {
            await DisplayAlert("", strMessage, "OK");
        }
        private void OnDelete()
        {

        }
    }
}
