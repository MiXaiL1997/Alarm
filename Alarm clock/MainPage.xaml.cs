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
            this.BindingContext = this;
            
        }

        private void FAB_Click(object sender, EventArgs e)
        {
            AlarmPicker.Focus();
            


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
                Cl = new ObservableCollection<Clocks>(Cl.OrderBy(x => x.Time));
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
                //Clocks.SetAlarm();
                var p = (StackLayout)sw.Parent;
                var c = (Label)p.Children[0];
                c.TextColor = Color.Black;
            }
            else
            {
                Switch sw = (Switch)sender;
                var Clocks = (Clocks)sw.BindingContext;
                //Clocks.OffAlarm();
                var p = (StackLayout)sw.Parent;
                var c = (Label)p.Children[0];
                c.TextColor = Color.Gray;
            }
            
            
        }

        private async void  ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            if (button.Rotation == 0)
            {
                await button.RotateTo(180, 250);
                var P = (StackLayout)button.Parent;
                var PP = (StackLayout)P.Parent;
                PP.Children[2].IsVisible = true;
                PP.Children[3].IsVisible = true;
                PP.Children[4].IsVisible = true;
            }
            else
            {
                await button.RotateTo(0, 250);
                var P = (StackLayout)button.Parent;
                var PP = (StackLayout)P.Parent;
                PP.Children[2].IsVisible = false;
                PP.Children[3].IsVisible = false;
                PP.Children[4].IsVisible = false;
            }
            



        }
    }
}
