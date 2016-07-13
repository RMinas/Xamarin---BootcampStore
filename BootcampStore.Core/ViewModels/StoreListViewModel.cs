using Acr.UserDialogs;
using BootcampStore.Core.Models;
using BootcampStore.Core.Services.Interfaces;
using MvvmCross.Core.ViewModels;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampStore.Core.ViewModels
{
    public class StoreListViewModel : MvxViewModel
    {
        private readonly IStoresService _storesService;
        private readonly IUserDialogs _dialogsService;
        private bool _isBusy;
        private ObservableCollection<Store> _stores;

        private MvxCommand _CreateCommand;
        private MvxCommand _refreshListCommand;

        public IMvxCommand CreateCommand => _CreateCommand ?? (_CreateCommand = new MvxCommand(Create));

        public IMvxCommand RefreshListCommand => 
            _refreshListCommand ?? (_refreshListCommand = new MvxCommand(async () => await RefreshList()));

        public INotifyTaskCompletion Initialization { get; private set; }

        public StoreListViewModel(IStoresService storesService, IUserDialogs dialogsService)
        {
            _storesService = storesService;
            _dialogsService = dialogsService;
            Initialization = NotifyTaskCompletion.Create(RefreshList);
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public ObservableCollection<Store> Stores
        {
            get
            {
                return _stores;
            }
            set
            {
                _stores = value;
                RaisePropertyChanged(() => Stores);
            }
        }

        private void Create()
        {
            ShowViewModel<CreateStoreViewModel>();
        }

        private async Task RefreshList()
        {
            IsBusy = true;
            try
            {
                var stores = await _storesService.GetStoresAsync();
                Stores = new ObservableCollection<Store>(stores);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await _dialogsService.AlertAsync("Problem Loading Stores!\nCheck Internet Connection.");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
