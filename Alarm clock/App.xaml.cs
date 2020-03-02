using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Alarm_clock
{
    public partial class App : Application
    {
        public static ObservableCollection<Clocks> Clocks { get; set; }
        public App()
        {
            InitializeComponent();
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "clocks.json"))
            {
                var jText = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "clocks.json", Encoding.UTF8);
                if (jText.Equals("") || jText.Equals(null) || jText.Equals("null"))
                {
                    Clocks = new ObservableCollection<Clocks>();
                }
                else
                {
                    //Clocks = JsonConvert.DeserializeObject<ObservableCollection<Clocks>>(jText);
                    Clocks = new ObservableCollection<Clocks>();
                }
                
            }
            else
            {
                Clocks = new ObservableCollection<Clocks>();
            }
            MainPage = new MainPage();
                
        }

        protected override void OnStart()
        {                   
        }

        protected override void OnSleep()
        {
            var Root = (MainPage as MainPage).Cl;
            var jRoot = JsonConvert.SerializeObject(Root);
            //File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "clocks.json", jRoot);
        }

        protected override void OnResume()
        {
            Debug.WriteLine("Resume");
        }

        
    }
}
