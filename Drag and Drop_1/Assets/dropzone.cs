using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public draggable.Slot typeOfItem = draggable.Slot.INVENTORY;

    //PointerEnter and Exit to check if the layout response to the mouse's position
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
        if(eventData.pointerDrag == null)
        {
            return;
        }

        draggable d = eventData.pointerDrag.GetComponent<draggable>();
        if (d != null)
        {
            d.placeholderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
        if (eventData.pointerDrag == null)
        {
            return;
        }

        draggable d = eventData.pointerDrag.GetComponent<draggable>();
        if (d != null && d.placeholderParent==this.transform)
        {
            d.placeholderParent = d.parentToReturnTo;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        //OnDrop cmd triggers before the OnEndDrag does
        //Debug.Log("OnDrop to " + gameObject.name);
        Debug.Log(eventData.pointerDrag.name + " was dropped " + gameObject.name);

        draggable d = eventData.pointerDrag.GetComponent<draggable>();
        if (d != null)
        {
            //if(typeOfItem == d.typeOfItem  || typeOfItem == draggable.Slot.INVENTORY)
            //{
                d.parentToReturnTo = this.transform;
            //}            
        }
    }



}