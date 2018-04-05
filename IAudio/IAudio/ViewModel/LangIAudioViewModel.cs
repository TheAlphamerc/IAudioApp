using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IAudio.ViewModel
{
    class LangIAudioViewModel : INotifyPropertyChanged
    {
        public LangIAudioViewModel()
        {
            ToggleStatusIcon = new Command(ToggleStatusIcon_clk);
            ToggleStatusIcon1 = new Command(ToggleStatusIcon1_clk);
            ToggleStatusIcon2 = new Command(ToggleStatusIcon2_clk);
            ToggleStatusIcon3 = new Command(ToggleStatusIcon3_clk);
            ToggleStatusIcon4 = new Command(ToggleStatusIcon4_clk);
            NavToMainPage = new Command(NavToMainPage_clk);
            NavToSettingPage = new Command(NavToSettingPage_clk);
            NavToNowPlaying = new Command(NavToNowPlaying_clk);
           
        }

        private void NavToNowPlaying_clk(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.NowPlaying());
        }

        private void NavToSettingPage_clk(object obj)
        {
            int i = 1;
            ViewModel.SettingViewModel call = new SettingViewModel(i);
            App.Current.MainPage.Navigation.PushAsync(new Views.Setting());
        }

        private void NavToMainPage_clk(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

        int c = 0,c1=0,c2=0,c3=0,c4=0;

        public event PropertyChangedEventHandler PropertyChanged;

       
        private void ToggleStatusIcon_clk(object obj)
        {
            if (c == 1)  {   statusIcon = "completed.png";  OnPropertyChanged("StatusIcon");  c = 0; }
            else         {   statusIcon = "completed1.png";   OnPropertyChanged("StatusIcon");   c = 11; }

        }
        private void ToggleStatusIcon1_clk(object obj)
        {
            if (c1 == 1) { statusIcon1 = "completed.png"; OnPropertyChanged("StatusIcon1"); c1 = 0; }
            else         { statusIcon1 = "completed1.png"; OnPropertyChanged("StatusIcon1"); c1 = 11; textStatus1 = "Completed"; OnPropertyChanged("TextStatus1"); }

        }
        private void ToggleStatusIcon2_clk(object obj)
        {
            if (c2 == 1) { statusIcon2 = "completed.png"; OnPropertyChanged("StatusIcon2"); c2 = 0; }
            else         { statusIcon2 = "completed1.png"; OnPropertyChanged("StatusIcon2"); c2 = 11; textStatus2 = "Completed"; OnPropertyChanged("TextStatus2"); }

        }
        private void ToggleStatusIcon3_clk(object obj)
        {
            if (c3 == 1) { statusIcon3 = "completed.png"; OnPropertyChanged("StatusIcon3"); c3 = 0; }
            else         { statusIcon3 = "completed1.png"; OnPropertyChanged("StatusIcon3"); c3= 11; textStatus3 = "Completed"; OnPropertyChanged("TextStatus3"); }

        }
        private void ToggleStatusIcon4_clk(object obj)
        {
            if (c4 == 1) { statusIcon4 = "completed.png"; OnPropertyChanged("StatusIcon4"); c4 = 0; }
            else         { statusIcon4 = "completed1.png"; OnPropertyChanged("StatusIcon4"); c4 = 11; textStatus4 = "Completed"; OnPropertyChanged("TextStatus4"); }

        }

        public ICommand ToggleStatusIcon { get; set; }
        public ICommand ToggleStatusIcon1 { get; set; }
        public ICommand ToggleStatusIcon2 { get; set; }
        public ICommand ToggleStatusIcon3 { get; set; }
        public ICommand ToggleStatusIcon4 { get; set; }
        public ICommand NavToMainPage { get; }
        public ICommand NavToSettingPage { get; }
        public ICommand NavToNowPlaying { get; set; }

        private String statusIcon = "completed.png";
        private String statusIcon1 = "completed.png";
        private String statusIcon2 = "completed.png";
        private String statusIcon3 = "completed.png";
        private String statusIcon4 = "completed.png";
        private string textStatus = "15m 19s remaining";
        private string textStatus1 = "15m 19s remaining";
        private string textStatus2 = "15m 19s remaining";
        private string textStatus3 = "15m 19s remaining";
        private string textStatus4 = "15m 19s remaining";


        public String StatusIcon { get { return statusIcon; } set { statusIcon = value; } }
        public String StatusIcon1 { get { return statusIcon1; } set { statusIcon1 = value; } }
        public String StatusIcon2 { get { return statusIcon2; } set { statusIcon2 = value; } }
        public String StatusIcon3 { get { return statusIcon3; } set { statusIcon3 = value; } }
        public String StatusIcon4 { get { return statusIcon4; } set { statusIcon4 = value; } }

        public String TextStatus { get { return textStatus; } set { textStatus = value; } }
        public String TextStatus1 { get { return textStatus1; } set { textStatus1 = value; } }
        public String TextStatus2 { get { return textStatus2; } set { textStatus2 = value; } }
        public String TextStatus3 { get { return textStatus3; } set { textStatus3 = value; } }
        public String TextStatus4 { get { return textStatus4; } set { textStatus4 = value; } }


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
