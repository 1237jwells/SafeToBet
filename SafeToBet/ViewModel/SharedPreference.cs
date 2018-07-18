using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace SafeToBet.ViewModel
{
    public class SharedPreference
    {
        // Uses Settings Template to create a Adjustable Account Variables
        //Creates a String Key Value
        private const String PhoneNumberKey = "_phoneNumber";
        //Creates a String.Empty Default Value
        private static readonly String PhoneNumberDefault = String.Empty;

        private const String LoggedInKey = "_LoggedIn";
        private static readonly String LoggedInDefault = String.Empty;

        private const String UsernameKey = "_username";
        private static readonly String UsernameDefault = String.Empty;

        private const String EmailKey = "_email";
        private static readonly String EmailDefault = String.Empty;

        private const String PasswordKey = "_password";
        private static readonly String PasswordDefault = String.Empty;

        private const String AboutmeKey = "_aboutme";
        private static readonly String AboutmeDefault = String.Empty;

        private static ISettings AppSettings
        {
            get 
            { 
                return CrossSettings.Current; 
            }    
        }

        public static String GetPhoneNumber
        {
            //Gets Value ((Key) if already given a value) or Default
            get { return AppSettings.GetValueOrDefault(PhoneNumberKey, PhoneNumberDefault); }
            //Updates Value (Key) from previous value
            set { AppSettings.AddOrUpdateValue(PhoneNumberKey, value); }
        }
        public static String GetLoginStatus
        {
            get { return AppSettings.GetValueOrDefault(LoggedInKey, LoggedInDefault); }
            set { AppSettings.AddOrUpdateValue(LoggedInKey, value); }
        }
        public static String GetUsername
        {
            get { return AppSettings.GetValueOrDefault(UsernameKey, UsernameDefault); }
            set { AppSettings.AddOrUpdateValue(UsernameKey, value); }
        }
        public static String GetEmailAddress
        {
            get { return AppSettings.GetValueOrDefault(EmailKey, EmailDefault); }
            set { AppSettings.AddOrUpdateValue(EmailKey, value); }
        }
        public static String GetPassword
        {
            get { return AppSettings.GetValueOrDefault(PasswordKey, PasswordDefault); }
            set { AppSettings.AddOrUpdateValue(PasswordKey, value); }
        }
        public static String GetAboutme
        {
            get { return AppSettings.GetValueOrDefault(AboutmeKey, AboutmeDefault); }
            set { AppSettings.AddOrUpdateValue(AboutmeKey, value); }
        }
    }
}
