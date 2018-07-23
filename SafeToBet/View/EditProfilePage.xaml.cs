using System;
using System.Collections.Generic;
using SafeToBet.Classes;
using SafeToBet.ViewModel;
using Xamarin.Forms;

namespace SafeToBet.View
{
    public partial class EditProfilePage : ContentPage
    {
        String strStatus;
        String strUsername;
        String strOldPassword;
        String strEmail;
        String strPhoneNumber;

        public EditProfilePage()
        {
            InitializeComponent();
            strStatus = SharedPreference.GetLoginStatus;
            strUsername = SharedPreference.GetUsername;
            strOldPassword = SharedPreference.GetPassword;
            strEmail = SharedPreference.GetEmailAddress;
            strPhoneNumber = SharedPreference.GetPhoneNumber;

            labelLoginStatus.Text = "Login Status: " + strStatus;
            labelUsername.Text = "Username: " + strUsername;
            labelPassword.Text = "Password: " + strOldPassword;
            labelEmail.Text = "Email: " + strEmail;
            labelPhoneNumber.Text = "PhoneNumber: " + strPhoneNumber;
        }
        /// <summary>
        /// Change Email
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        async void clickChangeEmail(object sender, System.EventArgs e)
        {
            strEmail = entryEmail.Text;

            if (isDataValidate())
            {
                if (App.Database.isUserExists(strUsername))
                {
                    var result = await DisplayAlert(Constant.APP_NAME, Constant.GOOD_EMAIL, Constant.YES, Constant.NO);

                    if (result == true)
                    {
                        SharedPreference.GetEmailAddress = strEmail;
                        App.Database.updateEmail(strUsername, strEmail);
                        entryEmail.Text = "";
                        labelEmail.Text = "Email: " + strEmail;
                        //await Navigation.PushModalAsync(new LoginForm());
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// Change Phone Number
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        async void clickChangePhoneNumber(object sender, System.EventArgs e)
        {
            strPhoneNumber = entryPhoneNumber.Text;

            if (isDataValidate())
            {
                if (App.Database.isUserExists(strUsername))
                {
                    var result = await DisplayAlert(Constant.APP_NAME, Constant.GOOD_PHONENUMBER, Constant.YES, Constant.NO);

                    if (result == true)
                    {
                        SharedPreference.GetPhoneNumber = strPhoneNumber;
                        App.Database.updatePhoneNumber(strUsername, strPhoneNumber);
                        entryPhoneNumber.Text = "";
                        labelPhoneNumber.Text = "Phone #: " + strPhoneNumber;
                        //await Navigation.PushModalAsync(new LoginForm());
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
            if (strPhoneNumber.Length == 0)
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
            return true;
        }
    }
}


