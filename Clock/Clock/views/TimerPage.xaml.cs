using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Timers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Clock;
using Clock.viewmodel;
using Clock.models;


namespace Clock.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        public TimerViewModel vm = new TimerViewModel();
       
 
        public TimerPage()
        {
            InitializeComponent();
            BindingContext = vm;
            

            ButtonPause_Resume.IsEnabled = false;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            MyTimers.ItemsSource = await App.Database.GetTimersAsync();

        }

        int count=0;
         protected void ButtonStart_Cancel_Clicked(object sender, EventArgs e)
        {
            count++;
            if (count == 1)
            {
                ButtonPause_Resume.IsEnabled = true;
                TimePicker.IsVisible = false;
                MyTimers.IsVisible = false;
                AddButton.IsVisible = false;
                TimerLabel.IsVisible = true;
                SeparatorLine.IsVisible = false;
                ButtonStart_Cancel.Text = "Cancel";
                   
                
                




            }

            else if (count == 2)
            {
                ButtonPause_Resume.IsEnabled = false;
                TimePicker.IsVisible = true;
                MyTimers.IsVisible = true;
                TimerLabel.IsVisible = false;
                AddButton.IsVisible = true;
               
                ButtonStart_Cancel.Text = "Start";
                ButtonPause_Resume.Text = "Pause";
              



                count = 0;
            }

            if(ButtonStart_Cancel.Text == "Start")
            {
                ButtonStart_Cancel.SetBinding(Button.CommandParameterProperty, new Binding("."));
                ButtonStart_Cancel.SetBinding(Button.CommandProperty, new Binding("StartCommand"));

            }

            else if(ButtonStart_Cancel.Text == "Cancel")
            {
                ButtonStart_Cancel.SetBinding(Button.CommandParameterProperty, new Binding("."));
                ButtonStart_Cancel.SetBinding(Button.CommandProperty, new Binding("StopCommand"));

            }













        }




        int Count = 0;
        private void ButtonPause_Resume_Clicked(object sender, EventArgs e)
        {
            Count++;
            if(Count == 1)
            {   
                ButtonPause_Resume.Text = "Resume";
               
            }
            else if(Count == 2)
            {
                
                ButtonPause_Resume.Text = "Pause";
                Count = 0;
            }


            if(ButtonPause_Resume.Text== "Resume")
            {
                ButtonPause_Resume.SetBinding(Button.CommandParameterProperty, new Binding("."));

                ButtonPause_Resume.SetBinding(Button.CommandProperty, new Binding("StartCommand"));

            }

            else if(ButtonPause_Resume.Text == "Pause")
            {
                ButtonPause_Resume.SetBinding(Button.CommandParameterProperty, new Binding("."));

                ButtonPause_Resume.SetBinding(Button.CommandProperty, new Binding("StopCommand"));

            }
        }

        private async void AddTime_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTimerPage
            {
                BindingContext=new TimerItem()

            });
        }

        private async void MyTimers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             var timer = e.CurrentSelection[0] as TimerItem;
           
            TimePicker.Time = timer.TimeSpan;

                





        }
    }
}