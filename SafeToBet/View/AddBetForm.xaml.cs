﻿using System;
using SafeToBet.Classes;
using Xamarin.Forms;
using SafeToBet.Data;
using SafeToBet.ViewModel;
using SafeToBet.Model;
using System.Collections.Generic;

namespace SafeToBet.View
{
    public partial class AddBetForm : ContentPage
    {
        //List<BetListModel> listItems = null;
        //BetList viewModel;
        //Strings start at nothing
        //int intBetId;
        String strBetName = "";
        String strBetDate = "";
        String strBetType = "";
        String strBetDescription = "";
        String strBetOpponent = "";
        String strBetAmount = "";

        public AddBetForm()
        {
            InitializeComponent();
            //Amount.Text = String.Format("Bet Amount: {0:C0}", e.NewValue);
            //BindingContext = ViewModel = new BetList();

        }

        void Handle_Amount(string sender, ValueChangedEventArgs e)
        {
            strBetAmount = Amount.Text = String.Format("{0:C0}", e.NewValue);

        }

        void Handle_DateSelected(object sender, DateChangedEventArgs e)
        {
            strBetDate = Amount.Text = String.Format("{0:D}", e.NewDate);
        }

        void Handle_Type(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                strBetType = Amount.Text = picker.Items[selectedIndex];
            }
        }

        void Save_Click(object sender, EventArgs e)
        {
            

            //Xaml text entryName.Text is now == string
            strBetName = entryBetName.Text;
            string newstrBetDate = strBetAmount;
            strBetDescription = entryBetDescription.Text;
            strBetOpponent = entryBetOpponent.Text;
            string newstrBetType = strBetType;


            BetListModel mBetList = new BetListModel();

            mBetList.BetName = strBetName;
            mBetList.BetDescription = strBetDescription;
            mBetList.BetDate = newstrBetDate;
            mBetList.BetOpponent = strBetOpponent;
            mBetList.BetAmount = strBetAmount;
            mBetList.BetType = newstrBetType;

            //listItems = new List<BetListModel>();
            //listItems.Add(new BetListModel()
            //{
            //    BetId = intBetId,
            //    BetName = strBetName,
            //    BetOpponent = strBetOpponent,
            //    BetDate = newstrBetDate,
            //    BetType = newstrBetType,
            //    BetDescription = strBetDescription,
            //    BetAmount = strBetAmount
            //});
                  
            //Saves as a new Databse Result
            int intSaveBetResult = App.DatabaseBet.SaveBetIntoDatabase(mBetList);
            openActionDialog(intSaveBetResult);
        }

        async private void openActionDialog(int intResult)
        {
            if (intResult == 1)
            {
                BetSharedPreference.GetBetName = strBetName;
                BetSharedPreference.GetBetDescription = strBetDescription;
                BetSharedPreference.GetBetDate = strBetDate;
                BetSharedPreference.GetBetOpponenet = strBetOpponent;
                BetSharedPreference.GetBetAmount = strBetAmount;
                BetSharedPreference.GetBetType = strBetType;
                App.Instance.ClearNavigationAndGoToPage(new DetailForm());
            }
            else
            {
                await DisplayAlert(Constant.APP_NAME, Constant.WRONG, Constant.OK);
            }

        }
    }
}
