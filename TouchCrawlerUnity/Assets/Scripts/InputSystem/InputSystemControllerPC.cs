using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InputSystem
{
    public class InputSystemControllerPC : MonoBehaviour
    {
        // Update is called once per frame
        /// <summary>
        /// Every single frame, checks to see if there is a touch, if the touch triggers an event, and if so, sends the event to the event system.
        /// </summary>
        private void Update()
        {
            var clicks = GetMouseClicks();
            IEvent e = ConvertTouchToEvent(clicks);
            SendInputEvent(e);
        }

        private Vector2[] GetMouseClicks()
        {
            if (Input.GetMouseButtonDown(0))
            {
                return new Vector2[] { Input.mousePosition };
            }
            else
            {
                return new Vector2[] { };
            }
        }

        /// <summary>
        /// Takes a touch and converts it to a ray.
        /// </summary>
        /// <param name="touch"></param>
        /// <returns></returns>
        private Ray ConvertMouseClickToRay(Vector2 mousePosition)
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(mousePosition);
            return ray;
        }

        /// <summary>
        /// Takes a touch and converts it to an Event - Attack or Move Event.
        /// </summary>
        /// <param name="touch"></param>
        /// <returns></returns>
        private IEvent ConvertTouchToEvent(Vector2[] mouseClicks)
        {

            RaycastHit hit;
            ITouchable touchable;

            foreach (Vector2 click in mouseClicks)
            {

                Ray ray = ConvertMouseClickToRay(click);
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