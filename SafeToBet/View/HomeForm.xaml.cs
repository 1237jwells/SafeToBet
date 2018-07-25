using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SafeToBet.ViewModel;
using SafeToBet.Classes;
using SafeToBet.Model;
using Xamarin.Forms;
using SafeToBet.View;

namespace SafeToBet
{
    public partial class HomeForm : ContentPage
    {
        public List<BetListModel> listItems = null;
        String strBetName;
        String strBetDate;
        String strBetType;
        String strBetDescription;
        String strBetOpponent;
        String strBetAmount;

        public HomeForm()
        {
            InitializeComponent();
            strBetName = BetSharedPreference.GetBetName;
            strBetDate = BetSharedPreference.GetBetDate;
            strBetType = BetSharedPreference.GetBetType;
            strBetDescription = BetSharedPreference.GetBetDescription;
            strBetOpponent = BetSharedPreference.GetBetOpponenet;
            strBetAmount = BetSharedPreference.GetBetAmount;

            //labelBetName.Text = "Name: " + strBetName;
            //labelBetDate.Text = "Date of Bet: " + strBetDate;
            //labelBetType.Text = "Type: " + strBetType;
            //labelBetDescription.Text = "Description: " + strBetDescription;
            //labelBetOpponent.Text = "Opponent: " + strBetOpponent;
            //labelBetAmount.Text = "Bet Amount: " + strBetAmount;

            listItems = new List<BetListModel>();
            listItems.Add(new BetListModel()
            {
                BetName = strBetName,
                BetOpponent = strBetOpponent,
                BetDate = strBetDate,
                BetType = strBetType,
                BetDescription = strBetDescription,
                BetAmount = strBetAmount
            });

            items.ItemsSource = listItems;

            String LoggedIn = SharedPreference.GetLoginStatus;
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
        async void BetTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            await Navigation.PushModalAsync(new BetDisplayForm());       
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
