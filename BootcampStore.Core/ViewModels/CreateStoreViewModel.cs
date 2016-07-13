using Acr.UserDialogs;
using BootcampStore.Core.Services.Interfaces;
using MvvmCross.Core.ViewModels;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BootcampStore.Core.ViewModels
{
    public class CreateStoreViewModel : MvxViewModel
    {
        private string _address;
        private bool _isBusy;
        private string _lat;
        private string _lng;
        private string _name;
        private string _phone;
        private string _photoUrl;

        private CancellationTokenSource _cts;
        private readonly IAddressLocationService _addressLocationService;
        private readonly IUserDialogs _dialogsService;
        private readonly IStoresService _storesService;

        private MvxCommand _createCommand;
        public IMvxCommand CreateCommand => _createCommand ?? (_createCommand = new MvxCommand(Create, CanExecute));

        public INotifyTaskCompletion AddressLocationSearch;

        public CreateStoreViewModel(IAddressLocationService addressLocationService,
            IUserDialogs dialogsService,
            IStoresService storesService)
        {
            _addressLocationService = addressLocationService;
            _dialogsService = dialogsService;
            _storesService = storesService;
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                CreateCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(() => Address);

                if (string.IsNullOrWhiteSpace(_address))
                {
                    Lat = Lng = null;
                }

                if(_cts != null && !_cts.IsCancellationRequested)
                {
                    _cts.Cancel();
                }

                _cts = new CancellationTokenSource();

                AddressLocationSearch = NotifyTaskCompletion.Create(SearchForCoordinates(value, _cts.Token));
            }
        }

        private async Task SearchForCoordinates(string address, CancellationToken token)
        {
            IsBusy = true;
            try
            {
                var location = await _addressLocationService.GetLocationAsync(address, token);
                Lat = location.Lat;
                Lng = location.Lng;
            }
            catch (Exception ex)
            {
                Lat = Lng = null;
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                CreateCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(() => Name);
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                CreateCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(() => Phone);
            }
        }

        public string PhotoUrl
        {
            get { return _photoUrl; }
            set
            {
                _photoUrl = value;
                CreateCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(() => PhotoUrl);
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                CreateCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public string Lat
        {
            get { return _lat; }
            set
            {
                _lat = value;
                RaisePropertyChanged(() => Lat);
            }
        }

        public string Lng
        {
            get { return _lng; }
            set
            {
                _lng = value;
                RaisePropertyChanged(() => Lng);
            }
        }

        private bool CanExecute()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                !string.IsNullOrWhiteSpace(Address) &&
                !string.IsNullOrWhiteSpace(Phone) &&
                !string.IsNullOrWhiteSpace(PhotoUrl) &&
                !string.IsNullOrWhiteSpace(Lat) &&
                !string.IsNullOrWhiteSpace(Lng) &&
                !IsBusy;
        }

        private async void Create()
        {
            IsBusy = true;

            try
            {
                await _storesService.CreateStoreAsync(Name, Address, Phone, PhotoUrl, Lat, Lng);
            }
            catch (Exception ex)
            {
                await _dialogsService.AlertAsync("Problem creating Store!\nCheck Internet Connection.");
            }
            finally
            {
                IsBusy = false;
            }

            Phone = string.Empty;
            Lat = string.Empty;
            Lng = string.Empty;
            Name = string.Empty;
            Address = string.Empty;
            PhotoUrl = string.Empty;

            Close(this);
        }
    }
}
