using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BootcampStore.Core.Models;
using BootcampStore.Core.Services.Interfaces;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid;
using Android.Locations;
using System.Globalization;

namespace BootcampStore.Droid.Services
{
    public class AddressLocationService : IAddressLocationService
    {
        public async Task<GeoLocation> GetLocationAsync(string address, CancellationToken ct = default(CancellationToken))
        {
            var globals = Mvx.Resolve<IMvxAndroidGlobals>();
            var geocoder = new Geocoder(globals.ApplicationContext);

            var addresses = await geocoder.GetFromLocationNameAsync(address, 1);

            var first = addresses.FirstOrDefault();

            if (first == null)
            {
                throw new Exception("No results found");
            }

            return new GeoLocation()
            {
                Lat = first.Latitude.ToString(CultureInfo.InvariantCulture),
                Lng = first.Longitude.ToString(CultureInfo.InstalledUICulture)
            };
        }
    }
}