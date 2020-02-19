using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryIcon : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Item item;

    RectTransform rectTransform;

    private Vector2 lastMousePosition;
    public Vector3 basePosition;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        basePosition = rectTransform.localPosition;
    }

    /// <summary>
    /// This method will be called on the start of the mouse drag
    /// </summary>
    /// <param name="eventData">mouse pointer event data</param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        lastMousePosition = eventData.position;
    }

    /// <summary>
    /// This method will be called during the mouse drag
    /// </summary>
    /// <param name="eventData">mouse pointer event data</param>
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentMousePosition = eventData.position;
        Vector2 diff = currentMousePosition - lastMousePosition;
        RectTransform rect = GetComponent<RectTransform>();

        Vector3 newPosition = rect.position + new Vector3(diff.x, diff.y, transform.position.z);
        Vector3 oldPos = rect.position;
        rect.position = newPosition;
        if (!IsRectTransformInsideSreen(rect))
        {
            rect.position = oldPos;
        }
        lastMousePosition = currentMousePosition;
    }

    /// <summary>
    /// This method will be called at the end of mouse drag
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.localPosition = basePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        if(results.Count == 0)
        {
            Assets.Scripts.Events.EventSystem.Broadcast(Assets.Scripts.Events.EventSystem.EventChannel.inventory, Assets.Scripts.Events.EventSystem.EventSubChannel.item, new DropItemEvent(item));
        }
    }

    /// <summary>
    /// This methods will check is the rect transform is inside the screen or not
    /// </summary>
    /// <param name="rectTransform">Rect Trasform</param>
    /// <returns></returns>
    private bool IsRectTransformInsideSreen(RectTransform rectTransform)
    {
        return true;
    }
}