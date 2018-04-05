using IAudioXamarin.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IAudio.ViewModel
{
    class SignInViewModel : ModelBase, INotifyPropertyChanged
    {
        public SignInViewModel()
        {
            NavToForgetPassword = new Command(NavigationToForgetPasswod_clk);
            ToggleCheckBox = new Command(ToggleCheckBox_clk);
        }
        #region Commands Declarations
        public ICommand NavToForgetPassword { get; set; }
        public ICommand ToggleCheckBox { get; set; }
        #endregion
        
        #region Page Navigation Methods

        private void NavigationToForgetPasswod_clk(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.ForgetPassword());
        }
        public void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.ForgetPassword());
        }

        #endregion

        #region Email Validation

        private string _email = "";
        [RegularExpression(@"^[A-Za-z0-9]([_A-Z-a-z0-9.!#$%&'*+-=?^`{|}~\\/]{2,20})*@([[A-Za-z]{1,15})\.([a-z]{2,15})$", ErrorMessage = "Email id should contain  one '@' and '.' special symbol")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter email")]
        [Display(Name = "           Emailid")]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "email should be within range 10 to 30 ")]
        public string Emailid
        {
            get { return _email; }
            set
            {
                _email = value;
                ValidateProperty(value);
                OnPropertyChanged("Emailid");
               
               
            }

        }

        #endregion

        private int emailErrMsgLength = 0;

        public int EmailErrMsgLength
        {
            get { return emailErrMsgLength; }
            set {
                  emailErrMsgLength = value; }
        }


        #region Password Validation
        private string _Password = "";
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Password must contain at least one upper,lower & special character ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter password")]
        [Display(Name = "           Password")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "email should be within range 8 to 16 ")]
       
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                ValidateProperty(value);
                OnPropertyChanged("Password");
            }

        }
        #endregion
        
        #region Toggle Check Box
        int c = 0;
        private String checkbox = "check.png";
        public String Checkbox
        {
            get { return checkbox; }
            set { checkbox = value; }
        }
        private void ToggleCheckBox_clk(object obj)
        {
            if (c == 1)
            {
                checkbox = "check.png";
                OnPropertyChanged("Checkbox");
                c = 0;
            }
            else
            {
                checkbox = "checked.png";
                OnPropertyChanged("Checkbox");
                c = 1;
            }

        }
        #endregion

        #region INotifyPropertyCganged Interface
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
