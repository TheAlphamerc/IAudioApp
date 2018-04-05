using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IAudio.ViewModel
{
    class SettingViewModel : INotifyPropertyChanged
    {
        int navigationReference ;
      
        public SettingViewModel()
        {
            NavToPrivacyPolicyPage     = new Command(NavToPrivacyPolicyPage_clk);
            NavToAboutUsPage           = new Command(NavToAboutUsPage_clk);
            BackNavigationPage         = new Command(BackNavigationPage_clk);
            NavToTermsAndConditionPage = new Command(NavToTermsAndConditionPage_clk);
        }
        public SettingViewModel(int I)
        {
            navigationReference = I;
        }

        #region Navigation To Page Methods
        private void BackNavigationPage_clk(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.LangAudio());
            //if (navigationReference == 1)
            //{
            //    App.Current.MainPage.Navigation.PushAsync(new Views.LangAudio());
            //}
            //if (navigationReference == 2)
            //{
            //    App.Current.MainPage.Navigation.PushAsync(new Views.NowPlaying());
            //}

        }
        private void NavToAboutUsPage_clk(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.AboutUs());
        }
        private void NavToPrivacyPolicyPage_clk(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.PrivacyPolicy());
        }

        private void NavToTermsAndConditionPage_clk(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.TermAndConditions());
        } 
        #endregion

        #region ICommand Declaration

        public ICommand NavToPrivacyPolicyPage { get; }
        public ICommand NavToAboutUsPage { get; private set; }
        public ICommand BackNavigationPage { get; private set; }
        public ICommand NavToTermsAndConditionPage { get; private set; }

        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

