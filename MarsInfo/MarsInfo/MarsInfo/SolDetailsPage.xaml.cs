using MarsInfo.Data.Curiosity;
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
    public partial class SolDetailsPage : ContentPage
    {
        ICuriosityManager mgr;
        private BESolCatalog catalog;
        private ImageViewerPage imgViewer;
        public SolDetailsPage(BESol inputSol)
        {
            InitializeComponent();
            mgr = CuriosityManagerFactory.Current;

            Setup(inputSol);

            btnRefresh.Clicked += (sender, e) => RefreshList();
        }
        private async void Setup(BESol inputSol)
        {
            catalog = await mgr.GetSolCatalog(inputSol);

            string updated = "Updated: " + catalog.most_recent;
            Title = updated;

            RefreshList();
        }
        protected override void OnAppearing()
        {
            RefreshList();
        }
        private void RefreshList()
        {
            lstView.ItemsSource = null;
            List<BEImage> imagesFound = new List<BEImage>();
            if (catalog != null)
            {
                var full = catalog.images.Where(x => x.sampleType == "full").ToList();
                imagesFound.AddRange(full);
                var chemcam = catalog.images.Where(x => x.sampleType == "chemcam prc").ToList();
                imagesFound.AddRange(chemcam);
            }
            lstView.ItemsSource = imagesFound;
        }
        private async void OpenInImageViewer(BEImage inputImg)
        {
            if (imgViewer == null)
            {
                imgViewer = new ImageViewerPage(inputImg);
            }
            else
            {
                imgViewer.OpenImage(inputImg);
            }
            await Navigation.PushAsync(imgViewer);
        }
        public void OpenDetails(BESol inputSol)
        {
            Setup(inputSol);
            RefreshList();
        }
        private void lstView_OnItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            var data = (BEImage)lstView.SelectedItem;
            OpenInImageViewer(data);
        }
    }
}