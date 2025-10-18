using FontAwesome.Sharp;
using System;
using System.Threading;
using System.Windows.Input;
using WPF_LoginForm.Models;
using WPF_LoginForm.Repositories;

namespace WPF_LoginForm.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // Fields
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        private IUserRepository userRepository;

        // Lazy Initialization for ViewModels
        private readonly Lazy<ViewModelBase> _anaMenuChildView = new(() => new AnaMenuViewModel());
        private readonly Lazy<ViewModelBase> _hesapkesimChildView = new(() => new HesapKesimViewModel());
        private readonly Lazy<ViewModelBase> _siparisChildView = new(() => new SiparisViewModel());
        private readonly Lazy<ViewModelBase> _KantarExcelChildView = new(() => new KantarExcelViewModel());
        private readonly Lazy<ViewModelBase> _fiyatgirisChildView = new(() => new FiyatGirisViewModel());
        private readonly Lazy<ViewModelBase> _ayarlarChildView = new(() => new AyarlarViewModel());

        // Properties
        public UserAccountModel CurrentUserAccount
        {
            get => _currentUserAccount;
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public ViewModelBase CurrentChildView
        {
            get => _currentChildView;
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        // Commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowHesapKesimViewCommand { get; }
        public ICommand ShowSiparisViewCommand { get; }
        public ICommand ShowKantarExcelViewCommand { get; }
        public ICommand ShowFiyatGirisViewCommand { get; }
        public ICommand ShowAyarlarViewCommand { get; }

        // Constructor
        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            // Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowViewCommand);
            ShowHesapKesimViewCommand = new ViewModelCommand(ExecuteHesapKesimViewCommand);
            ShowSiparisViewCommand = new ViewModelCommand(ExecuteSiparisViewCommand);
            ShowKantarExcelViewCommand = new ViewModelCommand(ExecuteKantarExcelViewCommand);
            ShowFiyatGirisViewCommand = new ViewModelCommand(ExecuteFiyatGirisViewCommand);
            ShowAyarlarViewCommand = new ViewModelCommand(ExecuteAyarlarViewCommand);

            // Default view
            CurrentChildView = _anaMenuChildView.Value;
            Caption = "Ana Menü";
            Icon = IconChar.Home;
        }

        // Command Execution Methods
        private void ExecuteShowViewCommand(object obj)
        {
            CurrentChildView = _anaMenuChildView.Value;
            Caption = "Ana Menü";
            Icon = IconChar.Home;
        }

        private void ExecuteHesapKesimViewCommand(object obj)
        {
            CurrentChildView = _hesapkesimChildView.Value;
            Caption = "Hesap Kesim";
            Icon = IconChar.Tags;
        }

        private void ExecuteSiparisViewCommand(object obj)
        {
            CurrentChildView = _siparisChildView.Value;
            Caption = "Sipariş";
            Icon = IconChar.HandshakeAngle;
        }

        private void ExecuteKantarExcelViewCommand(object obj)
        {
            CurrentChildView = _KantarExcelChildView.Value;
            Caption = "Kantar Excel Ekleme";
            Icon = IconChar.TruckFast;
        }

        private void ExecuteFiyatGirisViewCommand(object obj)
        {
            CurrentChildView = _fiyatgirisChildView.Value;
            Caption = "Fiyat Giriş";
            Icon = IconChar.FileInvoiceDollar;
        }

        private void ExecuteAyarlarViewCommand(object obj)
        {
            CurrentChildView = _ayarlarChildView.Value;
            Caption = "Ayarlar";
            Icon = IconChar.Sliders;
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"{user.Name} {user.LastName}";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                // Hide child views.
            }
        }
    }
}
