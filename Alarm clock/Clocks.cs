using Android.App;
using Android.Content;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Text;


namespace Alarm_clock
{
    public class Clocks
    {
        public Clocks()
        {
            manager = (AlarmManager)Application.Context.GetSystemService(Context.AlarmService);
            intent = new Intent(Application.Context, typeof(AlarmRecevier));
            pintent = PendingIntent.GetBroadcast(Application.Context, 0, intent, PendingIntentFlags.UpdateCurrent);
        }
        public TimeSpan time;
        public string Time { get { return new DateTime(time.Ticks).ToString("HH:mm"); } }
        public void SetTime(TimeSpan span)
        {
            time = span;

        }
        
        public string Descrption { get; set; }
        public bool Toggled { get; set; }
        public AlarmManager manager;
        public PendingIntent pintent;
        public Intent intent;
        public void SetAlarm()
        {
            Calendar calendar = Calendar.Instance;
            calendar.Set(CalendarField.HourOfDay, time.Hours);
            calendar.Set(CalendarField.Minute, time.Minutes);
            //manager.SetAlarmClock(AlarmManager.AlarmClockInfo.)
            manager.Set(AlarmType.RtcWakeup, calendar.TimeInMillis, pintent);
        }
        public void OffAlarm()
        {
            pintent.Cancel();
            manager.Cancel(pintent);
        }
    }

}
