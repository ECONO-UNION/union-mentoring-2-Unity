using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy.Events.Listener
{
    public interface IListener
    {
        void OnEvent(EVENT_TYPE Event_Type, Component Sender, object[] Param = null);
    }
}