//@author YD
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media.Abstractions;

namespace MobileProgramming_A3
{
    public partial class MainPage : ContentPage
    {  
        //PhoneBookList = [[]]
        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PhoneBook(), true);
        }

        async void Button_Clicked_Save(object sender, System.EventArgs e)
        {
            if(NameEntry.Text == "" || PhoneEntry.Text == "" || MailEntry.Text == "")
            {
                await DisplayAlert("Error!", "You can not leave areas empty!", "OK");
                return;
            }
            else
            {
                await DisplayAlert("Success!", "Data Saved Successfully!", "OK");
                return;
            }                
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Not Supported!", "Your device does not support this functionality!", "OK");
                return;
            }

            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Small
            };
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            if(selectedImage == null)
            {
                await DisplayAlert("Error!", "Could not upload photo, please try again!", "OK");
                return;
            }

            selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
        }


       
    }
}
