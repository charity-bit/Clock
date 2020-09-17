using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

namespace Clock.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StopWatchPage : ContentPage
    {
              private readonly Stopwatch stopWatch;
        




        public StopWatchPage()
        {
            InitializeComponent();
            stopWatch = new Stopwatch();
            LblStopWatch.Text = "00:00.00";
            

        }


        int count = 0;
        private void Button_Start(object sender, EventArgs e)
        {
            count++;


            if (count == 1)
            {
                if (!stopWatch.IsRunning)
                {
                    stopWatch.Start();

                    Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            LblStopWatch.Text = String.Format("{0:mm\\:ss\\:ff}", stopWatch.Elapsed);

                        });

                        BtnLap_Reset.IsEnabled = true;




                        if (!stopWatch.IsRunning)
                            return false;

                        return true;


                    });

                }

                BtnStop_Start.Text = "Stop";
                BtnLap_Reset.Text = "Lap";


            }

            else if (count == 2)

            {
                stopWatch.Stop();
                BtnStop_Start.Text = "Start";
                BtnLap_Reset.Text = "Reset";


                count = 0;

            }


        }

          
        

       
        




        private void Button_Lap(object sender, EventArgs e)
        {
             if(BtnLap_Reset.Text == "Reset")
            {
                stopWatch.Reset();
                LblStopWatch.Text = "00:00.00";
                BtnLap_Reset.Text = "Lap";
                BtnLap_Reset.IsEnabled = false;
                

            }
             if(BtnLap_Reset.Text == "Lap")
            {
                
              


            }
        }
    }
}