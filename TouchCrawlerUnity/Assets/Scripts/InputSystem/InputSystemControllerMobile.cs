using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InputSystem
{
    public class InputSystemControllerMobile : MonoBehaviour
    {
        // Update is called once per frame
        /// <summary>
        /// Every single frame, checks to see if there is a touch, if the touch triggers an event, and if so, sends the event to the event system.
        /// </summary>
        private void Update()
        {
            Touch[] touches = GetTouches();
            IEvent e = ConvertTouchToEvent(touches);
            SendInputEvent(e);
        }

        /// <summary>
        /// Makes an array of every time the screen is touched.
        /// </summary>
        /// <returns></returns>
        private Touch[] GetTouches()
        {
            return Input.touches;
        }

        /// <summary>
        /// Takes a touch and converts it to a ray.
        /// </summary>
        /// <param name="touch"></param>
        /// <returns></returns>
        private Ray ConvertTouchToRay(Touch touch)
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(touch.position);
            return ray;
        }

        /// <summary>
        /// Takes a touch and converts it to an Event - Attack or Move Event.
        /// </summary>
        /// <param name="touches"></param>
        /// <returns></returns>
        private IEvent ConvertTouchToEvent(Touch[] touches)
        {

            RaycastHit hit;
            ITouchable touchable;

            foreach (Touch touch in touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = ConvertTouchToRay(touch);
                    if (Physics.Raycast(ray, out hit))
                    {
                        touchable = hit.collider?.gameObject?.GetComponent<ITouchable>();
                        if (touchable != null)
                        {
                            return touchable.GetEvent();
                        }
                        else
                        {
                            return new MoveInputEvent(ray);
                        }
                    }
                    else
                    {
                        return new MoveInputEvent(ray);
                    }
                }

            }
            return null;
        }

        /// <summary>
        /// Sends an event to the event system.
        /// </summary>
        /// <param name="e"></param>
        private void SendInputEvent(IEvent e)
        {
            if (e != null)
            {
                EventSystem.Broadcast(EventSystem.EventChannel.player, EventSystem.EventSubChannel.input, e);
            }
        }
    }
}