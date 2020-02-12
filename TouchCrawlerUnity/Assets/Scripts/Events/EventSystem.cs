using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Events
{
    public class EventSystem : MonoBehaviour
    {
        private static EventSystem instance;

        private static List<string> log = new List<string>();
        public static IEnumerable<string> Log => log;

        public enum EventChannel
        {
            gameState,
            player,
        }

        public enum EventSubChannel
        {
            levelTransition,
            input,
            gameOver,
            item,
        }

        Dictionary<(EventChannel, EventSubChannel), List<IEventListener>> channels = new Dictionary<(EventChannel, EventSubChannel), List<IEventListener>>();

        static EventSystem()
        {
            instance = new GameObject("EventSystem").AddComponent<EventSystem>();
            DontDestroyOnLoad(instance);
            DontDestroyOnLoad(instance.gameObject);
            SceneManager.sceneLoaded += instance.OnSceneWasLoaded;
        }

        public static bool AddEventListener(EventChannel eventChannel, EventSubChannel eventSubChannel, IEventListener eventListener)
            => instance._AddEventListener(eventChannel, eventSubChannel, eventListener);

        private bool _AddEventListener(EventChannel eventChannel, EventSubChannel eventSubChannel, IEventListener eventListener)
        {
            var list = _GetEventList(eventChannel, eventSubChannel);
            if(!list.Contains(eventListener))
            {
                list.Add(eventListener);
                return true;
            }
            return false;
        }



        public static bool RemoveEventListener(EventChannel eventChannel, EventSubChannel eventSubChannel, IEventListener eventListener)
            => instance._RemoveEventListener(eventChannel, eventSubChannel, eventListener);

        private bool _RemoveEventListener(EventChannel eventChannel, EventSubChannel eventSubChannel, IEventListener eventListener)
        {
            var list = _GetEventList(eventChannel, eventSubChannel);
            if(list.Contains(eventListener))
            {
                list.Remove(eventListener);
                return true;
            }
            return false;
        }

        public static void Broadcast(EventChannel eventChannel, EventSubChannel eventSubChannel, IEvent e)
            => instance._Broadcast(eventChannel, eventSubChannel, e);

        private void _Broadcast(EventChannel eventChannel, EventSubChannel eventSubChannel, IEvent e)
        {
            string channelString = eventChannel.ToString();
            string subChannelString = eventSubChannel.ToString();

            AddToLog("(" + channelString + ", " + subChannelString + ") : " + e.ToString());

            var list = _GetEventList(eventChannel, eventSubChannel);
            foreach(var listener in list)
            {
                listener.AcceptEvent(e);
            }
        }

        private List<IEventListener> _GetEventList(EventChannel eventChannel, EventSubChannel eventSubChannel)
        {
            if(!channels.ContainsKey((eventChannel, eventSubChannel)))
            {
                channels[(eventChannel, eventSubChannel)] = new List<IEventListener>();
            }
            return channels[(eventChannel, eventSubChannel)];
        }

        private void OnSceneWasLoaded(Scene scene, LoadSceneMode mode)
        {
            UnityEngine.Debug.Log("Scene was loaded");
        }

        private void AddToLog(string message)
        {
            log.Add(message);
            if(log.Count > 50)
            {
                log.RemoveAt(0);
            }
        }
    }
}