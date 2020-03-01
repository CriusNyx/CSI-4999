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

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastMousePosition = eventData.position;
        item = this.transform.parent.GetChild(1).GetComponent<PickUpItem>().item;
        //Debug.Log("Name: " + this.name + " Item: " + this.transform.parent.GetChild(1).GetComponent<PickUpItem>().item.name);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentMousePosition = eventData.position;
        Vector2 diff = currentMousePosition - lastMousePosition;
        RectTransform rect = GetComponent<RectTransform>();

        Vector3 newPosition = rect.position + new Vector3(diff.x, diff.y, transform.position.z);
        Vector3 oldPosition = rect.position;
        rect.position = newPosition;

        if (!IsRectTransformInsideSreen(rect))
        {
            rect.position = oldPosition;
        }

        lastMousePosition = currentMousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.localPosition = basePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        if (results.Count == 0)
        {
            Assets.Scripts.Events.EventSystem.Broadcast(Assets.Scripts.Events.EventSystem.EventChannel.inventory, Assets.Scripts.Events.EventSystem.EventSubChannel.item, new DropItemEvent(item));
           // Debug.Log("Dropped - " + item.name);
        }
    }

    private bool IsRectTransformInsideSreen(RectTransform rectTransform)
    {
        return true;
    }
}