using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static partial class Core
{
    public delegate object GameEvent(object sender, object args);

    static Dictionary<string, GameEvent> _eventBag = new Dictionary<string, GameEvent>();
    public static void SubscribeEvent(string eventName, GameEvent eventObj)
    {
        //check if event is existing, if so subscribe to it
        GameEvent existing = null;
        if (_eventBag.TryGetValue(eventName, out existing))
            existing += eventObj; //delegate subscribe
        else
            existing = eventObj;

        _eventBag[eventName] = existing;//store it in the bag
    }

    public static object BroadcastEvent(string eventName, object sender, object args)
    {
        object retValue = null;
        //try to fetch event
        GameEvent existing = null;
        if (_eventBag.TryGetValue(eventName, out existing))
            retValue = existing(sender, args); //broadcast to all subscribers on that event

        return retValue;
    }
    public static void UnsubscribeEvent(string eventName, GameEvent eventObj)
    {
        //try to fetch event
        GameEvent existing = null;
        if (_eventBag.TryGetValue(eventName, out existing))
            existing -= eventObj; //delegate unsubscribe

        if (existing == null)
            _eventBag.Remove(eventName); //remove empty events
    }
    public static void ClearAllEvents()
    {
        _eventBag.Clear();
    }

    public static string GetAbsolutePath(string localPath)
    {
        return string.Format("{0}/{1}", Application.dataPath, localPath);
    }
}
