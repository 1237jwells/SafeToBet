using System;
using SafeToBet.Classes;
using Xamarin.Forms;
using SafeToBet.ViewModel;

namespace SafeToBet
{
    public partial class ChangePasswordForm : ContentPage
    {
        String strStatus;
        String strUsername;
        String strOldPassword;
        String strNewPassword;
        String strNewConfirmPassword;
        String strEmail;
        String strPhoneNumber;
       
        public ChangePasswordForm()
        {
            InitializeComponent();
            strUsername = SharedPreference.GetUsername;
            strOldPassword = SharedPreference.GetPassword;
            strEmail = SharedPreference.GetEmailAddress;
            strPhoneNumber = SharedPreference.GetPhoneNumber;

            labelUsername.Text = "Username: " + strUsername;
            labelPassword.Text = "Password: " + strOldPassword;
            labelEmail.Text = "Email: " + strEmail;
            labelPhoneNumber.Text = "Phone #: " + strPhoneNumber;
        }

        async void clickChangePassword(object sender, System.EventArgs e)
        {
            strOldPassword = entryOldPassword.Text;
            strNewPassword = entryNewPassword.Text;
            strNewConfirmPassword = entryNewConfirmPassword.Text;

            if (isDataValidate())
            {
                if (App.Database.isUserExists(strUsername))
                {
                    var result = await DisplayAlert(Constant.APP_NAME, Constant.RE_LOGIN_MESSAGE, Constant.YES, Constant.NO);

                    if (result == true)
                    {
                        SharedPreference.GetPassword = strNewPassword;
                        App.Database.updatePassword(strUsername, strNewPassword);
                        entryOldPassword.Text = "";
                        entryNewPassword.Text = "";
                        entryNewConfirmPassword.Text = "";
                        labelPassword.Text = "Password: " + strNewPassword;
                        await Navigation.PushModalAsync(new LoginForm());
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        private Boolean isDataValidate()
        {
            if (strOldPassword.Length == 0)
            {
                DisplayAlert(Constant.APP_NAME, Constant.ENTER_PASSWORD, Constant.OK);
                return false;
            }
            else if (SharedPreference.GetPassword != entryOldPassword.Text)
            {
                DisplayAlert(Constant.APP_NAME, Constant.INCORRECT_OLD_PASSWORD, Constant.OK);
                return false;
            }
            else if (strNewPassword.Length == 0)
            {
                DisplayAlert(Constant.APP_NAME, Constant.INCORRECT_NEW_PASSWORD, Constant.OK);
                return false;
            }
            else if (strNewConfirmPassword.Length == 0)
            {
                DisplayAlert(Constant.APP_NAME, Constant.ENTER_CONFIRM_PASSWORD, Constant.OK);
                return false;
            }
            else if (strOldPassword.Length < 6 || strNewConfirmPassword.Length < 6 || strNewPassword.Length < 6)
            {
                DisplayAlert(Constant.APP_NAME, Constant.ENTER_SHORT_PASSWORD, Constant.OK);
                return false;
            }
            else if (!strNewPassword.ToLower().Equals(strNewConfirmPassword.ToLower()))
            {
                DisplayAlert(Constant.APP_NAME, Constant.PASSWORD_NOT_MATCH, Constant.OK);
                return false;
            }
            return true;
        }
    }
}