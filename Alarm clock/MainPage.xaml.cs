using Android.App;
using Android.Content;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Alarm_clock
{
    public partial class MainPage : Shell
    {
        public ObservableCollection<Clocks> Cl { get; set; }
        public MainPage()
        {
            InitializeComponent();
            Cl = App.Clocks;
            //this.BindingContext = this;
            clocksList.ItemsSource = Cl;
            
        }

        private void FAB_Click(object sender, EventArgs e)
        {
            AlarmPicker.Focus();
            


        }

        public void UpdateToogles()
        {
            //clocksList.ItemsSource = null;
            for (int i = 0; i < Cl.Count; i++)
            {
                if (Cl[i].Toggled == true)
                {
                    var Item = Cl[i];
                    Cl.RemoveAt(i);
                    Item.Toggled = false;
                    Cl.Insert(i, Item);
                }
            }
            //clocksList.ItemsSource = Cl;
        }

        private void AlarmPicker_Unfocused(object sender, FocusEventArgs e)
        {
            
            
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }

        private void AlarmPicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
            {
                TimePicker picker = (TimePicker)sender;
                Clocks Item = new Clocks();
                Item.SetTime(picker.Time);
                Item.Toggled = true;
                Cl.Add(Item);
                //Cl = new ObservableCollection<Clocks>(Cl.OrderBy(x => x.Time));
                //clocksList.ItemsSource = null;
                //clocksList.ItemsSource = Cl;
            }
            
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            
            if (e.Value == true)
            {
                Switch sw = (Switch)sender;
                var Clocks = (Clocks)sw.BindingContext;
                Intent intent = new Intent(Android.App.Application.Context, typeof(AlarmRecevier));
                PendingIntent intent1 = PendingIntent.GetBroadcast(Android.App.Application.Context, Cl.Count, intent, PendingIntentFlags.OneShot);
                Clocks.SetAlarm(intent1);
                var p = (StackLayout)sw.Parent;
                var c = (Label)p.Children[0];
                c.TextColor = Color.Black;
            }
            else
            {
                Switch sw = (Switch)sender;
                var Clocks = (Clocks)sw.BindingContext;
                Clocks.OffAlarm();
                var p = (StackLayout)sw.Parent;
                var c = (Label)p.Children[0];
                c.TextColor = Color.Gray;
            }
            
            
        }

        private async void  ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            var P = (StackLayout)button.Parent;
            var PP = (StackLayout)P.Parent;
            
            if (button.Rotation == 0)
            {
                await button.RotateTo(180, 250);
                var A = new Animation(x => PP.Children[2].HeightRequest = x, 0, 200);
                A.Commit(this, "StakLAnimate", 16, 250, Easing.Linear);
            }
            else
            {
                await button.RotateTo(0, 250);
                var A = new Animation(x => PP.Children[2].HeightRequest = x, 200, 0);
                A.Commit(this, "StakLAnimate", 16, 250, Easing.Linear);
            }
            



        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var C = (CheckBox)sender;
            Clocks clocks = C.BindingContext as Clocks;
            //clocks.Repeat = C.IsChecked;
        }
    }
}
