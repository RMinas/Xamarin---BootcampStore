using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampStore.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        private MvxCommand _logoutCommand;
        private MvxCommand _showPromotionsCommand;
        private MvxCommand _showStoresComand;
        private MvxCommand _showStoresMapCommand;

        public IMvxCommand ShowStoresCommand => _showStoresComand = _showStoresComand ?? new MvxCommand(ShowStores);
        public IMvxCommand ShowPromotionsCommand => _showPromotionsCommand = _showPromotionsCommand ?? new MvxCommand(ShowPromotions);
        public IMvxCommand ShowStoresMapCommand => _showStoresMapCommand = _showStoresMapCommand ?? new MvxCommand(ShowStoresMap);
        public IMvxCommand LogoutCommand => _logoutCommand = _logoutCommand ?? new MvxCommand(Logout);

        private void ShowStores()
        {
            ShowViewModel<StoreListViewModel>();
        }

        private void ShowPromotions()
        {
            //ShowViewModel<PromotionsListViewModel>();
        }

        private void ShowStoresMap()
        {
			ShowViewModel<StoreMapViewModel>();
        }

        private void Logout()
        {
            ShowViewModel<LoginViewModel>();
        }
    }
}
