using System;
using SafeToBet.Classes;
using Xamarin.Forms;
using SafeToBet.Data;
using SafeToBet.ViewModel;

namespace SafeToBet
{
    public partial class SignUpForm : ContentPage
    {
        //Strings start at nothing
        String strUsername = "";
        String strEmail = "";
        String strPassword = "";
        String strConfirmPassword = "";
        String strPhoneNumber = "";

        public SignUpForm()
        {
            InitializeComponent();
        }
        void Back_Click(object sender, EventArgs e)
        {
             Navigation.PopModalAsync();
        }
        async void SignupClick(object sender, EventArgs e)
        {
            //Xaml text entryName.Text is now == string
            strUsername = entryUsername.Text;
            strEmail = entryEmail.Text;
            strPassword = entryPassword.Text;
            strConfirmPassword = entryConfirmPassword.Text;
            strPhoneNumber = entryPhoneNumber.Text;

            if(isDataValidate()){
                var result = await DisplayAlert(Constant.APP_NAME, Constant.CREATE_ACCOUNT, Constant.YES, Constant.NO);
                if (result)
                {
                    //updates the DatabaseModel
                    DatabaseModel mDatabaseModel = new DatabaseModel();
                    //String from user now == the mDatabaseModel data places
                    //mDatabaseModel == Email,Name,Password & PhoneNumber
                    mDatabaseModel.personEmail = strEmail;
                    mDatabaseModel.personUsername = strUsername;
                    mDatabaseModel.personPassword = strPassword;
                    mDatabaseModel.personPhoneNumber = strPhoneNumber;
                    //Saves as a new Database Result
                    int intSaveResult = App.Database.SaveDataIntoDatabase(mDatabaseModel);
                    openActionDialog(intSaveResult);
                }
            }
            else {
                return;
            }
        }
        async private void openActionDialog(int intResult)
        {
            if (intResult == 1)
            {
                await DisplayAlert(Constant.APP_NAME, Constant.SIGNUP_SUCCESS, null, Constant.OK);
                SharedPreference.GetLoginStatus = "true";
                SharedPreference.GetEmailAddress = strEmail;
                SharedPreference.GetUsername = strUsername;
                SharedPreference.GetPhoneNumber = strPhoneNumber;
                SharedPreference.GetPassword = strPassword;
                App.Instance.ClearNavigationAndGoToPage(new DetailForm());
            }
            else
            {
                await DisplayAlert(Constant.APP_NAME, Constant.SIGNUP_USER_EXIST, Constant.OK);
            }
        }



        //Is Validating
        private Boolean isDataValidate()
        {
            if (strUsername.Length == 0)
            {
                DisplayAlert(Constant.APP_NAME, Constant.ENTER_NAME, Constant.OK);
                return false;
            }
            else if (strPhoneNumber.Length == 0)
            {
                DisplayAlert(Constant.APP_NAME, Constant.ENTER_PHONE, Constant.OK);
                return false;
            }
            else if (strPhoneNumber.Length < 10)
            {
                DisplayAlert(Constant.APP_NAME, Constant.ENTER_VALID_PHONE, Constant.OK);
                return false;
            }
            else if (strEmail.Length == 0)
            {
                DisplayAlert(Constant.APP_NAME, Constant.ENTER_EMAIL, Constant.OK);
                return false;
            }
            else if (strPassword.Length == 0)
            {
                DisplayAlert(Constant.APP_NAME, Constant.ENTER_PASSWORD, Constant.OK);
                return false;
            }
            else if (strConfirmPassword.Length == 0)
            {
                DisplayAlert(Constant.APP_NAME, Constant.ENTER_CONFIRM_PASSWORD, Constant.OK);
                return false;
            }
            else if (strPassword.Length < 6 || strConfirmPassword.Length < 6)
            {
                DisplayAlert(Constant.APP_NAME, Constant.ENTER_SHORT_PASSWORD, Constant.OK);
                return false;
            }
            else if (!strPassword.ToLower().Equals(strConfirmPassword.ToLower()))
            {
                DisplayAlert(Constant.APP_NAME, Constant.PASSWORD_NOT_MATCH, Constant.OK);
                return false;
            }
            return true;
        }
    }
}