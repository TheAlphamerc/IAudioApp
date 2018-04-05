using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using System.Windows.Input;
using Xamarin.Forms;

namespace IAudio.ViewModel
{
    class AboutUsViewModel : INotifyPropertyChanged
    {

        public AboutUsViewModel()
        {
            NavToSettingPage = new Command(NavToSettingPage_clk);
        }

        private void NavToSettingPage_clk(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.Setting());
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand NavToSettingPage { get; }


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
