using System;
using SafeToBet.Classes;
using Xamarin.Forms;
using SafeToBet.Data;
using SafeToBet.ViewModel;
using SafeToBet.Model;

namespace SafeToBet.View
{
    public partial class AddBetForm : ContentPage
    {
        //BetList viewModel;
        //Strings start at nothing
        String strBetName = "";
        //String strBetDate = "";
        String strBetType = "";
        String strBetDescription = "";
        String strBetOpponent = "";
        //String strBetAmount = "";

        public AddBetForm()
        {
            InitializeComponent();
            //Amount.Text = String.Format("Bet Amount: {0:C0}", e.NewValue);
            Amount.Text = "Bet Amount: $10";
            //BindingContext = ViewModel = new BetList();
            BindingContext = new Pickers();

        }

        void Handle_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Amount.Text = String.Format("Bet Amount: {0:C0}", e.NewValue);
        }



        void Save_Click(object sender, EventArgs e)
        {
            //Xaml text entryName.Text is now == string
            strBetName = entryBetName.Text;
            //strBetDate = entryBetDate.Text;
            strBetDescription = entryBetDescription.Text;
            strBetOpponent = entryBetOpponent.Text;
            //strBetConfirm = entryBetAmount.Text;


            BetListModel mBetList = new BetListModel();

            mBetList.BetName = strBetName;
            mBetList.BetDescription = strBetDescription;
            mBetList.BetOpponent = strBetOpponent;
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
                BetSharedPreference.GetBetOpponenet = strBetOpponent;
                App.Instance.ClearNavigationAndGoToPage(new DetailForm());
            }
            else
            {
                await DisplayAlert(Constant.APP_NAME, Constant.WRONG, Constant.OK);
            }

        }
    }
}
