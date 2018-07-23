using System;
using System.Collections.Generic;
using SafeToBet.ViewModel;
using Xamarin.Forms;

namespace SafeToBet
{
    public partial class AboutMeForm : ContentPage
    {
        String strAboutme;

        public AboutMeForm()
        {
            InitializeComponent();
            strAboutme = SharedPreference.GetAboutme;
        }
        void Save_Click(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DetailForm());
        }
        void EditorCompleted(object sender, System.EventArgs e)
        {
            var text = ((Editor)sender).Text;
            text = SharedPreference.GetAboutme;
            //Color.LightGreen;
            // sender is cast to an Editor to enable reading the 'Text'
        }
        void EditorTextChanged (object sender, TextChangedEventArgs e){
            //var oldText = e.OldTextValue;
            //var newText = e.NewTextValue;
        }
    }
}