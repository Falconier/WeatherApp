using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
	//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LocationDetailPage : ContentPage
	{
        readonly DataManager _dataManager;
        private Location vm;
		public LocationDetailPage ()
		{
            _dataManager = DataManger.DefaultManager;
            vm = new Location();
            Title = "Location Details Page";
            InitializeComponent();
		}

        public LocationDetailsPage(Location location)
        {
            _dataManager = DataManger.DefaultManager;
            vm = location;
            Title = vm.Name;
            InitializeComponent();
        }

        private void OnSaveLocation(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnGetCurrentLocation(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

	}
}