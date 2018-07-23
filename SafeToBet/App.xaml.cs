using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SafeToBet.Data;
using SafeToBet.ViewModel;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SafeToBet
{
    public partial class App : Application
    {
        public static App Instance;
        public static PersonDatabase mPersonDatabase;
        public static BetList mBetList;

        public App()
        {
            InitializeComponent();
            Instance = this;

            var Dets = new DetailForm();
            var mainPage = new NavigationPage(Dets);
            Application.Current.MainPage = mainPage;
            //MainPage = new NavigationPage(new DetailForm());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public void ClearNavigationAndGoToPage(MasterDetailPage page)
        {
            MainPage = new NavigationPage(page);
        }   

        public static PersonDatabase Database
        {
            get{

                if (mPersonDatabase == null)
                {
                    mPersonDatabase = new PersonDatabase(DependencyService.Get<iLocalFileHelper>().GetLocalFilePath("SafeToBet_Database.db3"));
                }
                return mPersonDatabase;
            }
        }

        public static BetList DatabaseBet
        {
            get
            {

                if (mBetList == null)
                {
                    mBetList = new BetList(DependencyService.Get<iLocalFileHelper>().GetLocalFilePath("SafeToBet_Database.db3"));
                }
                return mBetList;
            }
        }

        public void GoToLoginScreen(ContentPage contentPage)
        {
            MainPage = new NavigationPage(new LoginForm());
        }
    }
}
