using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BootcampStore.Core;
using Android.Gms.Maps;
using MvvmCross.Droid.Views;
using System.Collections.ObjectModel;
using BootcampStore.Core.Models;
using Android.Gms.Maps.Model;
using System.Globalization;

namespace BootcampStore.Droid.Activities
{
    [Activity(Label = "StoreMapActivity",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        WindowSoftInputMode = SoftInput.StateHidden)]
    public class StoreMapActivity : MvxActivity<StoreMapViewModel>, IOnMapReadyCallback
    {
        private GoogleMap _map;
        private MapView _mapView;
        private ObservableCollection<Store> _storeList;
        private StoreMapViewModel _storeMapViewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.store_map);

            _mapView = FindViewById<MapView>(Resource.Id.mapView);
            _mapView.OnCreate(savedInstanceState);

            _mapView.GetMapAsync(this);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _map = googleMap;
            LoadStoresToMapAsync();
        }

        private async void LoadStoresToMapAsync()
        {
            await ViewModel.Initialization.Task;
            _storeList = ViewModel.Stores;

            if(_map != null)
            {
                foreach (var store in _storeList)
                {
                    var markerOptions = CreateMarker(store);
                    _map.AddMarker(markerOptions);
                }
            }
        }

        private static MarkerOptions CreateMarker(Store store)
        {
            LatLng latLng;
            try
            {
                latLng = new LatLng(
                    double.Parse(store.Lat, CultureInfo.InvariantCulture),
                    double.Parse(store.Lng, CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                latLng = new LatLng(0.0, 0.0);
            }

            var markerOptions = new MarkerOptions()
                .SetPosition(latLng)
                .Draggable(false)
                .SetTitle(store.Name);

            return markerOptions;
        }
    }
}