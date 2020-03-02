using Android.App;
using Android.Content;
using Android.Provider;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Alarm_clock;


namespace Alarm_clock
{
    public class Clocks
    {
        public Clocks()
        { 
            //Repeat = false;
        }
        public TimeSpan time;
        public string Time { get { return new DateTime(time.Ticks).ToString("HH:mm"); } }

        public void SetTime(TimeSpan span)
        {
            time = span;

        }      
        public string Descrption { get; set; }
        public bool Toggled { get; set; }
        //public bool Repeat { get; set; }
        public AlarmManager manager;
        PendingIntent pintent;
        public void SetAlarm(PendingIntent pintent)
        {
            this.pintent = pintent;
            manager = (AlarmManager)Application.Context.GetSystemService(Context.AlarmService);
            Calendar calendar = Calendar.Instance;
            calendar.Set(CalendarField.HourOfDay, time.Hours);
            calendar.Set(CalendarField.Minute, time.Minutes);
            manager.SetAlarmClock(new AlarmManager.AlarmClockInfo(calendar.Time.Time, pintent), pintent);
            //manager.Set(AlarmType.RtcWakeup, calendar.TimeInMillis, pintent);
        }
        public void OffAlarm()
        {
            if (pintent == null)
                return;
            manager.Cancel(pintent);
        }
    }

}
