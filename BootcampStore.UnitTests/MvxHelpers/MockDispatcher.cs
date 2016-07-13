using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace BootcampStore.UnitTests.MvxHelpers
{
    public class MockDispatcher : MvxMainThreadDispatcher, IMvxViewDispatcher
    {
        public List<MvxViewModelRequest> RequestList = new List<MvxViewModelRequest>();
        public List<IMvxViewModel> CloseList = new List<IMvxViewModel>();

        public bool ChangePresentation(MvxPresentationHint hint)
        {
            var closeHint = hint as MvxClosePresentationHint;
            if (closeHint == null)
            {
                throw new NotImplementedException();
            }

            return Close(closeHint.ViewModelToClose);
        }

        public bool RequestMainThreadAction(Action action)
        {
            action();
            return true;
        }

        public bool ShowViewModel(MvxViewModelRequest request)
        {
            RequestList.Add(request);
            return true;
        }

        private bool Close(IMvxViewModel viewModelToClose)
        {
            CloseList.Add(viewModelToClose);
            return true;
        }
    }
}
