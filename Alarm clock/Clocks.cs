using System;
using System.Collections.Generic;
using System.Text;

namespace Alarm_clock
{
    public class Clocks
    {
        public TimeSpan time;
        public string Time { get { return new DateTime(time.Ticks).ToString("HH:mm"); } }
        public void SetTime(TimeSpan span)
        {
            time = span;
        }
        public string Descrption { get; set; }
        public bool Toggled { get; set; }
    }

}
