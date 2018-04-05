using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IAudio.ViewModel
{
    class NowPlayingViewModel : INotifyPropertyChanged
    {
        public NowPlayingViewModel()
        {
            NavToLangIAudio = new Command(NavigationToLangIAudio_clk);
            CancelButton = new Command(CloseChapterList);
            OpenButton = new Command(OpenChapterList);
            NavToSettingPage = new Command(NavToSettingPage_clk);
        }

        #region Navigatio to Page
        private void NavToSettingPage_clk(object obj)
        {
            int i = 2;
            ViewModel.SettingViewModel call = new SettingViewModel(i);
            App.Current.MainPage.Navigation.PushAsync(new Views.Setting());
        }
        private void NavigationToLangIAudio_clk(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.LangAudio());
        } 
        #endregion
        #region ICommands
        public ICommand NavToSettingPage { get; }
        public ICommand NavToLangIAudio { get; }
        public ICommand CancelButton { get; set; }
        public ICommand OpenButton { get;  set; }
        #endregion
        #region Variables Declarations
        private bool isVisible = false;
        #endregion

        public bool IsVisible { get { return isVisible; } set { isVisible = value; OnPropertyChanged("IsVisible"); } }

        #region Private Methods
        private void OpenChapterList(object obj) { isVisible = true; OnPropertyChanged("IsVisible"); }
        private void CloseChapterList(object obj) { isVisible = false; OnPropertyChanged("IsVisible"); }

        #endregion
        #region INotifyProperty Changed Interface

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
