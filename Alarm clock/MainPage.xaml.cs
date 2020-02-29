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
                clocksList.ItemsSource = null;
                clocksList.ItemsSource = Cl;
            }
            
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                Switch sw = (Switch)sender;
                var p = (StackLayout)sw.Parent;
                var c = (Label)p.Children[0];
                c.TextColor = Color.Black;
            }
            else
            {
                Switch sw = (Switch)sender;
                var p = (StackLayout)sw.Parent;
                var c = (Label)p.Children[0];
                c.TextColor = Color.Gray;
            }
            
            
        }
    }
}
