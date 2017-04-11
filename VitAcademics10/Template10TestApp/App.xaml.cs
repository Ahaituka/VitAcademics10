using Windows.UI.Xaml;
using System.Threading.Tasks;
using Template10TestApp.Services.SettingsServices;
using Windows.ApplicationModel.Activation;
using Template10.Controls;
using Template10.Common;
using System;
using System.Linq;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Controls;
using Template10TestApp.Views;
using AcademicsLibrary.Managers;
using System.Diagnostics;
using AcademicsLibrary.NetworkService;
using Windows.Foundation.Collections;
using Windows.Storage;
using AcademicsLibrary.Helpers;

namespace Template10TestApp
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    [Bindable]
    sealed partial class App : BootStrapper
    {

        public string user;
        public string pass;
        public string campus;
        public DataManager.StatusCode status;
            
        public App()
        {
            InitializeComponent();
            SplashFactory = (e) => new Views.Splash(e);

            #region app settings

            // some settings must be set in app.constructor
            var settings = SettingsService.Instance;
            RequestedTheme = settings.AppTheme;
            CacheMaxDuration = settings.CacheMaxDuration;
            ShowShellBackButton = settings.UseShellBackButton;
            AutoSuspendAllFrames = true;
            AutoRestoreAfterTerminated = true;
            AutoExtendExecutionSession = true;

            #endregion
        }

        public override UIElement CreateRootElement(IActivatedEventArgs e)
        {
            var service = NavigationServiceFactory(BackButton.Attach, ExistingContent.Exclude);
            return new ModalDialog
            {
                DisableBackButtonWhenModal = true,
                Content = new Views.Shell(service),
                ModalContent = new Views.Busy(),
            };
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {


            IPropertySet roamingProperties = ApplicationData.Current.RoamingSettings.Values;
            if (roamingProperties.ContainsKey("HasBeenHereBefore"))
            {
                // TODO: add your long-running task here
                try
                {
                    var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                    user = localSettings.Values["user"].ToString();
                    pass = localSettings.Values["pass"].ToString();
                    campus = localSettings.Values["campus"].ToString();
                }
                catch
                {
                    Shell.HamburgerMenu.IsFullScreen = true;
                    NavigationService.Navigate(typeof(Views.LoginPage));
                    return;

                }              

             //   Debug.WriteLine("Data Status: {0} ", DataManager.IsReady)
                 var isInternet =  await  NetworkService.IsInternet();


                if (isInternet)
                {
                    try
                    {
                        Busy.SetBusy(true, "Refreshing ");                       
                        status = await DataManager.LoginAsync(campus, user, pass);                        
                        Busy.SetBusy(false);
                        //   await DataManager.RefreshDataAsync(campus, user, pass);

                    }
                    catch { }
                }
                else
                {
                    try
                    {
                       // if (status != DataManager.StatusCode.Success)
                            await DataManager.LoadCacheAsync();
                    }
                    catch
                    {


                    }
                }

                if (DataManager.IsReady)
                {
                    NavigationService.Navigate(typeof(Views.MainPage));
                }
                else if (!DataManager.IsReady)
                {
                    
                         Shell.HamburgerMenu.IsFullScreen = true;
                        //    Shell.HamburgerMenu.IsFullScreen = true;
                        NavigationService.Navigate(typeof(Views.LoginPage));
                        //MessageDialog.ShowDialog("Sorry No INTERNET ");
                    
                }

               await Task.CompletedTask;               
                // The normal case
                //await NavigationService.NavigateAsync(typeof(Views.MainPage));
            }
            else
            {
                // The first-time case
                Shell.HamburgerMenu.IsFullScreen = true;
                await NavigationService.NavigateAsync(typeof(Views.LoginPage));
                var _localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                _localSettings.Values["oneshot"] = "true";
                roamingProperties["HasBeenHereBefore"] = bool.TrueString; // Doesn't really matter what
            }


         
        }
    }
}

