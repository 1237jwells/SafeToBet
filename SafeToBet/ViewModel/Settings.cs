using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace SafeToBet.Helpers
{
    /// <summary>
    /// /Creates a Default string "" and a key String "value"
    /// 
    /// This is a Template for SharedPreference which gives Account Variables Values;
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }
        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion

        public static string GeneralSettings
        {
            get { return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault); }
            set { AppSettings.AddOrUpdateValue(SettingsKey, value); }
        }
    }
}