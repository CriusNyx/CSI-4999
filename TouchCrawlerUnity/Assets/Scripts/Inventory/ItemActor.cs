using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Events;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemActor : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    //, IEventListener
{
    private float startX;
    private float startY;
    bool isBeingDragged = false;

    void Update()
    {
        if (isBeingDragged)
        {
            Vector3 mousePosition;
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            this.gameObject.transform.position = new Vector3(mousePosition.x - startX, mousePosition.y - startY, 0);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition;
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            startX = mousePosition.x - this.gameObject.transform.position.x;
            startY = mousePosition.y - this.gameObject.transform.position.y;

            isBeingDragged = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingDragged = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
    }

    #region Input System Code (Not Implemented)
    /*
    void Start()
    {
        EventSystem.AddEventListener(EventSystem.EventChannel.inventory, EventSystem.EventSubChannel.item, this);
    }

    public void AcceptEvent(IEvent e)
    {
        if (e is DragInputEvent dragInputEvent)
        {
            // Logic
        }
        if (e is InputUpInputEvent inputUpInputEvent)
        {
            // Logic
        }
    }*/
    #endregion
}
