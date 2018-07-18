using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace SafeToBet.ViewModel
{
    public class BetSharedPreference
    {
        // Uses Settings Template to create a Adjustable Account Variables
        //Creates a String Key Value
        private const String NameKey = "_name";
        //Creates a String.Empty Default Value
        private static readonly String NameDefault = String.Empty;
        private const String DateStartKey = "_dateStart";
        private static readonly String DateStartDefault = String.Empty;
        private const String DateEndKey = "_dateEnd";
        private static readonly String DateEndDefault = String.Empty;
        private const String TypeKey = "_type";
        private static readonly String TypeDefault = String.Empty;
        private const String DescriptionKey = "_description";
        private static readonly String DescriptionDefault = String.Empty;
        private const String OpponentKey = "_opponent";
        private static readonly String OpponentDefault = String.Empty;
        private const String AmountKey = "_amount";
        private static readonly String AmountDefault = String.Empty;

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        public static String GetBetName
        {
            //Gets Value ((Key) if already given a value) or Default
            get { return AppSettings.GetValueOrDefault(NameKey, NameDefault); }
            //Updates Value (Key) from previous value
            set { AppSettings.AddOrUpdateValue(NameKey, value); }
        }
        public static String GetBetDateStart
        {
            get { return AppSettings.GetValueOrDefault(DateStartKey, DateStartDefault); }
            set { AppSettings.AddOrUpdateValue(DateStartKey, value); }
        }
        public static String GetBetDateEnd
        {
            get { return AppSettings.GetValueOrDefault(DateEndKey, DateEndDefault); }
            set { AppSettings.AddOrUpdateValue(DateEndKey, value); }
        }
        public static String GetBetType
        {
            get { return AppSettings.GetValueOrDefault(TypeKey, TypeDefault); }
            set { AppSettings.AddOrUpdateValue(TypeKey, value); }
        }
        public static String GetBetDescription
        {
            get { return AppSettings.GetValueOrDefault(DescriptionKey, DescriptionDefault); }
            set { AppSettings.AddOrUpdateValue(DescriptionKey, value); }
        }
        public static String GetBetOpponenet
        {
            get { return AppSettings.GetValueOrDefault(OpponentKey, OpponentDefault); }
            set { AppSettings.AddOrUpdateValue(OpponentKey, value); }
        }
        public static String GetBetAmount
        {
            get { return AppSettings.GetValueOrDefault(AmountKey, AmountDefault); }
            set { AppSettings.AddOrUpdateValue(AmountKey, value); }
        }
    }
}

