using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IAudio.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NowPlaying : ContentPage
	{
		public NowPlaying ()
		{
			InitializeComponent ();
            listView.ItemsSource = GetItems(); 
        }
        public List<ItemViewModel> GetItems()
        {
            var lorem = "Chapter-1 Chapter-2 Chapter-3 Chapter-4 Chapter-5 Chapter-6 Chapter-7 Chapter-8 Chapter-9 Chapter-10 Chapter-11 Chapter-12 Chapter-13 Chapter-14".Split(' ');
            var items = new List<ItemViewModel>();
            for (int i = 0; i < 14; i++)
            {
                items.Add(new ItemViewModel() { Text = lorem[i] });
            }
            return items;
        }
      
        public class ItemViewModel
        {
            public string Text { get; set; }
        }


    }
}