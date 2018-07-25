using System;
using System.Collections.Generic;
using SafeToBet.Classes;
using SafeToBet.Model;
using SafeToBet.ViewModel;
using Xamarin.Forms;

namespace SafeToBet.View
{
    public partial class BetDisplayForm : ContentPage
    {
        String strBetName;
        String strBetDate;
        String strBetType;
        String strBetDescription;
        String strBetOpponent;
        String strBetAmount;

        public BetDisplayForm()
        {
            InitializeComponent();
            strBetName = BetSharedPreference.GetBetName;
            strBetDate = BetSharedPreference.GetBetDate;
            strBetType = BetSharedPreference.GetBetType;
            strBetDescription = BetSharedPreference.GetBetDescription;
            strBetOpponent = BetSharedPreference.GetBetOpponenet;
            strBetAmount = BetSharedPreference.GetBetAmount;

            labelBetName.Text = "Name: " + strBetName;
            labelBetDate.Text = "Date of Bet: " + strBetDate;
            labelBetType.Text = "Type: " + strBetType;
            labelBetDescription.Text = "Description: " + strBetDescription;
            labelBetOpponent.Text = "Opponent: " + strBetOpponent;
            labelBetAmount.Text = "Bet Amount: " + strBetAmount;

        }

        void Back_Click(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        void EditBet_Click(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new EditBetForm());
        }

        async void Delete_Click(object sender, System.EventArgs e)
        {
            var result = await DisplayAlert(Constant.APP_NAME, Constant.DELETE_BET, Constant.YES, Constant.NO);

            if (result == true)
            {
                //int data = await 



                strBetName = BetSharedPreference.GetBetName;
                await App.DatabaseBet.deleteBet(strBetName);
                BetSharedPreference.GetBetName = "";
                BetSharedPreference.GetBetDate = "";
                BetSharedPreference.GetBetType = "";
                BetSharedPreference.GetBetDescription = "";
                BetSharedPreference.GetBetOpponenet = "";
                BetSharedPreference.GetBetAmount = "";


                App.Instance.ClearNavigationAndGoToPage(new DetailForm());
            }
            else
            {
                return;
            }
        }

    }
}