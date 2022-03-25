using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
public class AndroidNotificationSystem : MonoBehaviour
{
    
    void Start()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
        var notification = new AndroidNotification();
        notification.Title = "Your Title";
        notification.Text = "Your Text";
        notification.FireTime = System.DateTime.Now.AddMinutes(1);

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }

    
}
