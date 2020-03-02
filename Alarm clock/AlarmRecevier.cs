using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Icu.Text;
using Android.Media;
using Android.OS;
using Android.Widget;
using Java.Util;
using Microsoft.VisualStudio.Services.Client;
using System;
using Android.Net;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using static Android.Resource;
using Application = Android.App.Application;
using Android;

namespace Alarm_clock
{
    [BroadcastReceiver]
    public class AlarmRecevier : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Vibrator vibrator = (Vibrator)context.GetSystemService(Context.VibratorService);
            vibrator.Vibrate(2000);

            Notification notification = new Notification.Builder(context)
                .SetContentTitle("Будильник!!")
                .SetSmallIcon(Resource.Drawable.IcDialogAlert)
                .SetContentText("Вставай!").Build();

            NotificationManager manager = (NotificationManager)context.GetSystemService(Context.NotificationService);
            notification.Flags = NotificationFlags.AutoCancel;
            manager.Notify(0, notification);

            Android.Net.Uri uri = RingtoneManager.GetDefaultUri(RingtoneType.Alarm);

            Ringtone r = RingtoneManager.GetRingtone(context, uri);
            r.Play();
            var Page = (App)App.Current;
            var MainPage = (MainPage)Page.MainPage;
            MainPage.UpdateToogles();

        }
    }
}