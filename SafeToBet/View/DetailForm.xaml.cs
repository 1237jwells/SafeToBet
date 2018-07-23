using System;
using SafeToBet.Classes;
using Xamarin.Forms;
using SafeToBet.Data;
using SafeToBet.ViewModel;
using SafeToBet.View;
using System.Diagnostics;

namespace SafeToBet
{

    public partial class DetailForm : MasterDetailPage
    {
        String strLoginStatus;
        String strUsername;

        public DetailForm()
        {
            InitializeComponent();

            strLoginStatus = SharedPreference.GetLoginStatus;

            if (strLoginStatus.ToLower().Equals("false"))
            {
                Navigation.PushModalAsync(new LoginForm());
            }
            else
            {
                //DatabaseModel mDatabaseModel = App.Database.getUserData(strUsername).Result;
                //strUsername = mDatabaseModel.personUsername;

                //strUsername = SharedPreference.GetUsername;
                labelUsername.Text = "Welcome, " + strUsername;
                changeNavigationPage(new HomeForm());
            }
        }





        void openHome(object sender, System.EventArgs e)
        {
            changeNavigationPage(new HomeForm());
        }
        void openChangePassword(object sender, System.EventArgs e)
        {
            changeNavigationPage(new ChangePasswordForm());
        }
        void openChangeProfile(object sender, System.EventArgs e)
        {
            changeNavigationPage(new EditProfilePage());
        }
        void openAboutUs(object sender, System.EventArgs e)
        {
            changeNavigationPage(new AboutMeForm());
        }
        void openNewBet(object sender, System.EventArgs e)
        {
            changeNavigationPage(new AddBetForm());
        }
        async void openLogout(object sender, System.EventArgs e)
        {
            var result = await DisplayAlert(Constant.APP_NAME, Constant.LOGOUT_MESSAGE, Constant.YES, Constant.NO);

            if (result == true)
            {
                SharedPreference.GetLoginStatus = "false";

                await Navigation.PushModalAsync(new LoginForm());
                DatabaseModel mDatabaseModel = new DatabaseModel();
            }
            else
            {
                return;
            }
        }


        protected async void deleteAccount(object sender, EventArgs e)
        {
            DatabaseModel mDatabaseModel = new DatabaseModel();
            mDatabaseModel.personUsername = strUsername;


            var result = await DisplayAlert(Constant.APP_NAME, Constant.DELETE_ACCOUNT, Constant.YES, Constant.NO);

            if (result == true)
            {
                int data = await App.Database.deleteAccount(mDatabaseModel);
                await Navigation.PushModalAsync(new LoginForm());
            }
            else
            {
                return;
            }
        }

        private void changeNavigationPage(ContentPage contentPage)
        {
            Detail = new NavigationPage(contentPage);
        }

    }
}
