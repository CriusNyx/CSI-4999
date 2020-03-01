using Assets.Scripts.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InputSystem
{
    public class InputSystemController : MonoBehaviour
    {
        public Texture2D cursor;

        Vector3 mousePositionLastFrame;

        private void Start()
        {
            mousePositionLastFrame = Input.mousePosition;

            //var croppedTexture = new Texture2D((int)cursor.rect.width, (int)cursor.rect.height);
            //var pixels = cursor.texture.GetPixels((int)cursor.textureRect.x,
            //                                        (int)cursor.textureRect.y,
            //                                        (int)cursor.textureRect.width,
            //                                        (int)cursor.textureRect.height);
            //croppedTexture.SetPixels(pixels);
            //croppedTexture.Apply();

            Cursor.SetCursor(cursor, new Vector2(8, 1.9f), CursorMode.Auto);
        }

        // Update is called once per frame
        /// <summary>
        /// Every single frame, checks to see if there is a touch, if the touch triggers an event, and if so, sends the event to the event system.
        /// </summary>
        private void Update()
        {
            var inputs = GetInputs();
            foreach(var input in inputs)
            {
                IEvent e = ConvertInputToEvent(input);
                SendInputEvent(e);
            }

        }

        private GameInput[] GetInputs()
        {
            List<GameInput> inputs = new List<GameInput>();

            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                // Prevent movement on UI click
                return new GameInput[0];
            }
            else
            {

                if (Input.GetMouseButtonDown(0))
                {
                    inputs.Add(new GameInput(GameInput.EventType.down, Vector2.zero, Input.mousePosition));
                }
                if (Input.GetMouseButtonUp(0))
                {
                    inputs.Add(new GameInput(GameInput.EventType.up, Vector2.zero, Input.mousePosition));
                }
                if (mousePositionLastFrame != Input.mousePosition)
                {
                    inputs.Add(new GameInput(GameInput.EventType.drag, Input.mousePosition - mousePositionLastFrame, Input.mousePosition));
                }

                foreach (var touch in Input.touches)
                {
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            inputs.Add(new GameInput(GameInput.EventType.down, Vector2.zero, touch.position));
                            break;
                        case TouchPhase.Ended:
                            inputs.Add(new GameInput(GameInput.EventType.up, Vector2.zero, touch.position));
                            break;
                        case TouchPhase.Moved:
                            inputs.Add(new GameInput(GameInput.EventType.drag, touch.deltaPosition, touch.position));
                            break;
                    }
                }

                mousePositionLastFrame = Input.mousePosition;

                return inputs.ToArray();
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
        private IEvent ConvertInputToEvent(GameInput input)
        {

            RaycastHit hit;
            ITouchable touchable;

            Ray ray = ConvertMouseClickToRay(input.inputPosition);

            switch(input.eventType)
            {
                case GameInput.EventType.down:
                    if(Physics.Raycast(ray, out hit))
                    {
                        touchable = hit.collider?.gameObject?.GetComponent<ITouchable>();
                        if(touchable != null)
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
                case GameInput.EventType.up:
                    return new InputUpInputEvent(input.inputPosition);
                case GameInput.EventType.drag:
                    return new DragInputEvent(input.inputPosition, input.delta);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Sends an event to the event system.
        /// </summary>
        /// <param name="e"></param>
        private void SendInputEvent(IEvent e)
        {
            if(e != null)
            {
                EventSystem.Broadcast(EventSystem.EventChannel.player, EventSystem.EventSubChannel.input, e);
            }
        }
    }
}