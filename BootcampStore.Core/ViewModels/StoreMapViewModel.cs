using System;
using Acr.UserDialogs;
using BootcampStore.Core.Services.Interfaces;
using BootcampStore.Core.ViewModels;

namespace BootcampStore.Core
{
	public class StoreMapViewModel : StoreListViewModel
	{
		public StoreMapViewModel(IStoresService storesService, IUserDialogs dservices) : base(storesService, dservices)
		{
			
		}
	}
}

