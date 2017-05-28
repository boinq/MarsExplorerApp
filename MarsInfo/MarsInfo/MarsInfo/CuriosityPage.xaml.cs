using MarsInfo.Data.Curiosity;
using MarsInfo.Data.Database;
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
    public partial class CuriosityPage : ContentPage
    {
        ICuriosityManager mgr;
        private BECuriosityManifest currentManifest;
        private SolDetailsPage detailsPage;
        public CuriosityPage()
        {
            InitializeComponent();
            mgr = CuriosityManagerFactory.Current;
            btnRefresh.Clicked += (sender, e) => RefreshList();
            RefreshList();
        }
        protected override void OnAppearing()
        {
            RefreshList();
        }
        private async void RefreshList()
        {
            if (currentManifest == null)
            {
                currentManifest = await mgr.GetManifest();
            }
            lstView.ItemsSource = null;
            lstView.ItemsSource = currentManifest.sols;
        }
        private async void OpenDetails(BESol inputSol)
        {
            if (detailsPage == null)
            {
                detailsPage = new SolDetailsPage(inputSol);
            }
            else
            {
                detailsPage.OpenDetails(inputSol);
            }
            await Navigation.PushAsync(detailsPage);
        }
        private void lstView_OnItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            BESol selectedSol = (BESol)lstView.SelectedItem;
            OpenDetails(selectedSol);
        }
    }
}
