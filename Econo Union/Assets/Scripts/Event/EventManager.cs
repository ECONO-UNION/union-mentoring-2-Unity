using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy.Events.Listener
{
    public enum EVENT_TYPE
    {
        ATTACK,
        JUMP,

        MOVE,

    }

    public class EventManager : MonoBehaviour
    {
        #region Properties

        public static EventManager Instance
        {
            get { return instance; }
        }

        #endregion

        #region Fields

        public static EventManager instance;

        /// <summary>
        /// 리스너 오브젝트가 담겨있는 컬렉션
        /// </summary>
        private Dictionary<EVENT_TYPE, List<IListener>> Listeners = new Dictionary<EVENT_TYPE, List<IListener>>();

        #endregion

        #region Callbacks

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
                DestroyImmediate(this);

        }

        #endregion

        #region Methods

        /// <summary>
        /// 리스너 오브젝트를 추가하는 메소드
        /// </summary>
        public void AddListener(EVENT_TYPE Event_Type, IListener Listener)
        {
            List<IListener> ListenList = null;

            if (Listeners.TryGetValue(Event_Type, out ListenList))
            {
                ListenList.Add(Listener);
                return;
            }

            ListenList = new List<IListener>();
            ListenList.Add(Listener);
            Listeners.Add(Event_Type, ListenList);
        }

        /// <summary>
        /// 이벤트를 리스너에게 전달하는 메소드
        /// </summary>
        public void PostNotification(EVENT_TYPE Event_Type, Component Sender, object[] Param = null)
        {
            List<IListener> ListenList = null;

            if (!Listeners.TryGetValue(Event_Type, out ListenList))
            {
                return;
            }

            for (int i = 0; i < ListenList.Count; i++)
            {
                if (ListenList[i] != null)
                {
                    ListenList[i].OnEvent(Event_Type, Sender, Param);
                }
            }
        }

        /// <summary>
        /// 딕셔너리에서 특정 이벤트 타입에 해당하는 리스너를 제거하는 메소드
        /// </summary>
        /// <param name="Event_Type"></param>
        public void RemoveEvent(EVENT_TYPE Event_Type)
        {
            Listeners.Remove(Event_Type);
        }

        /// <summary>
        /// 딕셔너리에서 쓸모없는 항목들을 제거하는 메소드
        /// </summary>
        public void RemoveRedundancies()
        {
            Dictionary<EVENT_TYPE, List<IListener>> tmpListeners = new Dictionary<EVENT_TYPE, List<IListener>>();

            foreach (var Item in Listeners)
            {
                for (int i = Item.Value.Count - 1; i >= 0; i--)
                {
                    if (Item.Value[i] == null)
                        Item.Value.RemoveAt(i);
                }

                if (Item.Value.Count > 0)
                    tmpListeners.Add(Item.Key, Item.Value);
            }

            Listeners = tmpListeners;
        }

        /// <summary>
        /// 씬이 변경될 때 호출된다.
        /// </summary>
        void OnLevelWasLoaded()
        {
            RemoveRedundancies();
        }

        #endregion
    }
}

namespace Easy.Events.Delegate
{
    public enum EVENT_TYPE
    {
        ATTACK,
        JUMP,

        MOVE,

    }

    public class EventManager : MonoBehaviour
    {
        #region Properties

        public static EventManager Instance
        {
            get { return instance; }
        }

        #endregion

        #region Fields

        public static EventManager instance;

        /// <summary>
        /// 이벤트 델리게이트
        /// </summary>
        public delegate void OnEvent(EVENT_TYPE Event_Type, Component Sender, object[] Param = null);

        /// <summary>
        /// 리스너 오브젝트가 담겨있는 컬렉션
        /// </summary>
        private Dictionary<EVENT_TYPE, List<OnEvent>> Listeners = new Dictionary<EVENT_TYPE, List<OnEvent>>();

        #endregion

        #region Callbacks

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                DestroyImmediate(this);
            }

        }

        #endregion

        #region Methods

        /// <summary>
        /// 리스너를 추가하는 메소드
        /// </summary>
        public void AddListener(EVENT_TYPE Event_Type, OnEvent Listener)
        {
            List<OnEvent> ListenList = null;

            if (Listeners.TryGetValue(Event_Type, out ListenList))
            {
                ListenList.Add(Listener);
                return;
            }

            ListenList = new List<OnEvent>();
            ListenList.Add(Listener);
            Listeners.Add(Event_Type, ListenList);
        }

        /// <summary>
        /// 이벤트를 리스너에게 전달하는 메소드
        /// </summary>
        public void PostNotification(EVENT_TYPE Event_Type, Component Sender, object[] Param = null)
        {
            List<OnEvent> ListenList = null;

            if (!Listeners.TryGetValue(Event_Type, out ListenList))
            {
                return;
            }

            for (int i = 0; i < ListenList.Count; i++)
            {
                if (ListenList[i] != null)
                {
                    ListenList[i](Event_Type, Sender, Param);
                }
            }
        }

        /// <summary>
        /// 딕셔너리에서 특정 이벤트 타입에 해당하는 리스너를 제거하는 메소드
        /// </summary>
        /// <param name="Event_Type"></param>
        public void RemoveEvent(EVENT_TYPE Event_Type)
        {
            Listeners.Remove(Event_Type);
        }

        /// <summary>
        /// 딕셔너리에서 쓸모없는 항목들을 제거하는 메소드
        /// </summary>
        public void RemoveRedundancies()
        {
            Dictionary<EVENT_TYPE, List<OnEvent>> tmpListeners = new Dictionary<EVENT_TYPE, List<OnEvent>>();

            foreach (var Item in Listeners)
            {
                for (int i = Item.Value.Count - 1; i >= 0; i--)
                {
                    if (Item.Value[i] == null)
                        Item.Value.RemoveAt(i);
                }

                if (Item.Value.Count > 0)
                    tmpListeners.Add(Item.Key, Item.Value);
            }

            Listeners = tmpListeners;
        }

        /// <summary>
        /// 씬이 변경될 때 호출된다.
        /// </summary>
        void OnLevelWasLoaded()
        {
            RemoveRedundancies();
        }

        #endregion
    }
}