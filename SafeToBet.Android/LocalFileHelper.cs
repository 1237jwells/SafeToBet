using System;
using System.IO;
using SafeToBet.Droid;
using SafeToBet.ViewModel;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileHelper))]


namespace SafeToBet.Droid
                   
{
    public class LocalFileHelper : iLocalFileHelper
    {
       public string GetLocalFilePath(string filePath)
        {

            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Database");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filePath);
        }
    }
}