using MarsInfo.Entities.Curiosity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarsInfo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageViewerPage : ContentPage
    {
        private BEImage imageToShow;
        public ImageViewerPage(BEImage inputImg)
        {
            InitializeComponent();
            imageToShow = inputImg;
            OpenImage(imageToShow);
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {

                Device.OpenUri(new Uri(imageToShow.urlList));
            };
            imgRover.GestureRecognizers.Add(tapGestureRecognizer);
        }
        public void OpenImage(BEImage inputImg)
        {
            imageToShow = inputImg;
            string added = "Added: " + imageToShow.lmst;
            Title = added;

            DownloadAndSetImage(imageToShow.urlList);

            txtInstrument.Text = imageToShow.instrument;
            txtContributor.Text = imageToShow.contributor;
            txtDateAdded.Text = imageToShow.dateAdded;
            txtXyz.Text = imageToShow.xyz;
        }
        private void DownloadAndSetImage(string url)
        {
            Uri uri = new Uri(url);
            imgRover.Source = ImageSource.FromUri(uri);
        }
    }
}
