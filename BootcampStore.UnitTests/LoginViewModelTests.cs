using Acr.UserDialogs;
using BootcampStore.Core.Models;
using BootcampStore.Core.ViewModels;
using BootcampStore.Core.Services.Interfaces;
using BootcampStore.UnitTests.MvxHelpers;
using MvvmCross.Test.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using Moq;
using System.Threading;

namespace BootcampStore.UnitTests
{
    [TestFixture]
    public class LoginViewModelTests : MvxIoCSupportingTest
    {
        private MockDispatcher _mockDispatcher;
        private readonly User _user = new User() { Username = "user", Password = "pass" };
        private IAuthenticationService _authService;
        private LoginViewModel _viewModel;
        private IUserDialogs _dialogsService;

        [SetUp]
        public void Init()
        {
            ClearAll(); //Sets Up the IOC Framework

            _mockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(_mockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(_mockDispatcher);

            _authService = Mock.Of<IAuthenticationService>();
            _dialogsService = Mock.Of<IUserDialogs>();

            _viewModel = new LoginViewModel(_authService, _dialogsService);
        }

        [Test]
        public void LoginCommand_ShouldClearCredentialsOnSuccess()
        {
            _viewModel.Username = _user.Username;
            _viewModel.Password = _user.Password;

            _viewModel.LoginCommand.Execute();


            Assert.IsNull(_viewModel.Username);
            Assert.IsNull(_viewModel.Password);
        }

        [Test]
        public void LoginCommand_ShouldCallDialogWithErrorMessageOnError()
        {
            var exception = new Exception("Login Failed.");

            Mock.Get(_authService)
                .Setup(xws => xws.LoginAsync(_user.Username, _user.Password, CancellationToken.None))
                .Throws(exception);

            _viewModel.Username = _user.Username;
            _viewModel.Password = _user.Password;

            _viewModel.LoginCommand.Execute(null);

            Mock.Get(_dialogsService)
                .Verify(n => n.Alert("Invalid Username or Password.", null, null), Times.Once);
        }
    }
}
