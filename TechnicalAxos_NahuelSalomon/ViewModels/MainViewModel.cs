using System.ComponentModel;
using TechnicalAxos_NahuelSalomon.Services;
using CommunityToolkit.Mvvm.Input;
using TechnicalAxos_NahuelSalomon.Utils;
using TechnicalAxos_NahuelSalomon.Models;
using System.Collections.ObjectModel;

namespace TechnicalAxos_NahuelSalomon.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            SetPackageName();
            SelectImageCommand = new AsyncRelayCommand(SelectImageAsync);
            LoadCountriesCommand = new AsyncRelayCommand(LoadCountries);
            SelectedImage = AppConstants.DefaultUrlImage;
        }

        private string _packageName;
        public string PackageName
        {
            get { return _packageName; }
            set
            {
                _packageName = value;
                OnPropertyChanged("PackageName");
            }
        }

        private string _selectedImage;
        public string SelectedImage
        {
            get { return _selectedImage; }
            set
            {
                _selectedImage = value;
                OnPropertyChanged("SelectedImage");
            }
        }

        private ObservableCollection<Country> _countries { get; set; }
        public  ObservableCollection<Country> Countries
        {
            get { return _countries; }
            set
            {
                _countries = value;
                OnPropertyChanged("Countries");
            }
        }

        public IAsyncRelayCommand SelectImageCommand { private set; get; }
        public IAsyncRelayCommand LoadCountriesCommand { private set; get; }

        public void SetPackageName() 
        {
            var dependencyService = DependencyService.Get<IAppInfoService>();
            PackageName = dependencyService != null ?
                                DependencyService.Get<IAppInfoService>().GetAppIdentifier() : 
                                AppConstants.NoInstanceDependencyService;
        }

        private async Task LoadCountries() 
        {
            Countries = new ObservableCollection<Country>(await new CountryService().GetAllAsync());
        }

        private async Task SelectImageAsync()
        {
            try
            {
                if (MediaPicker.IsCaptureSupported)
                {
                    var file = await MediaPicker.PickPhotoAsync();
                    SelectedImage = file != null ? file.FullPath : string.Empty;
                }
            }
            catch (FeatureNotSupportedException)
            {
                await Application.Current!.MainPage!.DisplayAlert(AppConstants.ErrorMessage, AppConstants.DeviceIncompatibleMessage, AppConstants.OkMessage);
            }
            catch (PermissionException)
            {
                await Application.Current!.MainPage!.DisplayAlert(AppConstants.ErrorMessage, AppConstants.PermitsNotGrantedMessage, AppConstants.OkMessage);
            }
            catch (Exception ex)
            {
                await Application.Current!.MainPage!.DisplayAlert(AppConstants.ErrorMessage, $"An error has occurred: {ex.Message}", AppConstants.OkMessage);
            }
        }

        #region Property changed 

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
