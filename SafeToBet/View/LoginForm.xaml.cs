using System;
using SafeToBet.Classes;
using Xamarin.Forms;
using SafeToBet.ViewModel;
using SafeToBet.Data;
using System.Diagnostics;

namespace SafeToBet
{
    public partial class LoginForm : ContentPage
    {

        String strUsername = "", strPassword = "";


        public LoginForm()
        {
            InitializeComponent();
            displayDatabaseData();
            displayBetDatabaseData();
            //labelUsers = displayDatabaseData();
        }
        async void displayDatabaseData()
        {
            foreach (var item in await App.Database.GetPersonListing())
            {
                //Debug.WriteLine("strId >> " + item.id);

            }
        }
        async void displayBetDatabaseData()
        {
            foreach (var item in await App.DatabaseBet.GetBetsListing())
            {
                //Debug.WriteLine("strId >> " + item.id);

            }
        }
        void Login_Clicked(object sender, System.EventArgs e)
        {
            //strPhoneNumber = entryPhoneNumber.Text;
            strUsername = entryUsername.Text;
            strPassword = entryPassword.Text;

            if (isDataValidate())
            {
                performAction(App.Database.isUserAuthenticated(strUsername, strPassword));
            }
        }
        async void performAction(Boolean result)
        {
            if (result)
            {
                //DatabaseModel mDatabaseModel = new DatabaseModel();
                //await DisplayAlert(Constant.APP_NAME, Constant.LOGIN_SUCCESS, null, "OK");
                //SharedPreference.GetPhoneNumber = strPhoneNumber;
                //strPhoneNumber = mDatabaseModel.personPhoneNumber;
                //strEmail = mDatabaseModel.personEmail;


                SharedPreference.GetLoginStatus = "true";
                SharedPreference.GetUsername = strUsername;
                SharedPreference.GetPassword = strPassword;
                await App.Database.getUserData(strUsername);
                //SharedPreference.GetPhoneNumber = 
                //SharedPreference.GetEmailAddress = 
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert(Constant.APP_NAME, Constant.LOGIN_FAILURE, null, "OK");
            }
        }
        private Boolean isDataValidate()
        {
            if (strUsername.Length == 0)
            {
                DisplayAlert(Constant.APP_NAME, Constant.ENTER_NAME, Constant.OK);
                return false;
            }
            else if (strPassword.Length == 0)
            {
                DisplayAlert(Constant.APP_NAME, Constant.ENTER_PASSWORD, Constant.OK);
                return false;
            }
            else if (strPassword.Length < 6)
            {
                DisplayAlert(Constant.APP_NAME, Constant.ENTER_SHORT_PASSWORD, Constant.OK);
                return false;
            }
            return true;
        }
        async void SignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUpForm());
        }
    }
}

