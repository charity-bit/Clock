using Clock.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Clock.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTimerPage : ContentPage
    {     public string title { get; set; }
          public  TimeSpan timespan { get; set; }
        public AddTimerPage(TimerItem timer)
        {
            InitializeComponent();
            title = timer.Title;
            timespan = timer.TimeSpan;
            this.BindingContext = this;
        }
        public AddTimerPage()
        {
            InitializeComponent();
        }


        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var timer = (TimerItem)BindingContext;
            if(timer.Title == null)
            {
                timer.Title = "Timer";
            }
            await App.Database.SaveTimerAsync(timer);
            await Navigation.PopAsync();

        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}