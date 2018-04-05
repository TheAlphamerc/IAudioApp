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
    class ForgetPasswordViewModel : ModelBase, INotifyPropertyChanged
    {
        public ForgetPasswordViewModel()
        {
            NavToMainPage = new Command(NavigationToMainPage_clk);
            Send = new Command(Send_clk);
        }

        #region  Page Navigation Methods And Message Box Visibility
        private void Send_clk(object obj)
        {
            IsVisible = true;
          //  opacity = .4F;
            OnPropertyChanged("Opacity");
           //bgColor = Color.FromRgba(102, 100, 106, 0.5);
        }

        private void NavigationToMainPage_clk(object obj)
        {
           // IsVisible = false;
         //   opacity = 1;

            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
        #endregion

        #region ICommand Declaretions
        public ICommand NavToForgetPassword { get; set; }
        public ICommand ToggleCheckBox { get; set; }
        public ICommand NavToMainPage { get; set; }
        public ICommand Send { get; set; }

        #endregion

        //private Color bgColor = Color.Transparent;
        //public Color BgColor
        //{
        //    get { return bgColor; }
        //    set
        //    {
        //        bgColor = value;
        //        OnPropertyChanged("BgColor");
        //    }
        //}

        //public  float   opacity = 4F;
        //public float Opacity
        //{
        //    get { return opacity; }
        //    set { opacity = value;
        //        OnPropertyChanged("Opacity");
        //    }
        //}

        private bool isVisible = false;
        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value;
                OnPropertyChanged("IsVisible");
            }
        }

        #region Email Validation 
        private string _email = "";
        [RegularExpression(@"^[A-Za-z0-9]([_A-Z-a-z0-9.!#$%&'*+-=?^`{|}~\\/]{2,20})*@([[A-Za-z]{1,15})\.([a-z]{2,15})$", ErrorMessage = "Enter Valid email format")]
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

        #region INotifyPropertyChanged Interface
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion


    }
}
