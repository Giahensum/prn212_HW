using BusinessLogicLayer.Services;
using GiaWPF.Commands;
using GiaWPF.Services;
using System.Windows;
using System.Windows.Input;
// Xóa các dòng using trùng lặp

namespace GiaWPF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAuthenticationService _authService;

        public LoginViewModel()
        {
            _authService = ServiceContainer.GetService<IAuthenticationService>();
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
            ExitCommand = new RelayCommand(ExecuteExit);
        }

        private string _email = string.Empty;
        public string Email
        {
            get => _email;
            set
            {
                SetProperty(ref _email, value);
                ClearError();
            }
        }

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
                ClearError();
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand ExitCommand { get; }

        public event EventHandler<AuthenticationResult>? LoginSuccess;

        private bool CanExecuteLogin()
        {
            return !IsBusy && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
        }

        private async void ExecuteLogin()
        {
            try
            {
                IsBusy = true;
                ClearError();

                await Task.Delay(500);

                var result = _authService.Login(Email.Trim(), Password);

                if (result.IsSuccess)
                {
                    LoginSuccess?.Invoke(this, result);
                }
                else
                {
                    SetError(result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                SetError($"Login failed: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void ExecuteExit()
        {
            Application.Current.Shutdown();
        }
    }
}
