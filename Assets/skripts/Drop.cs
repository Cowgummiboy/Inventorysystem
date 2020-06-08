using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    private SateCheck sateCheck;
    private SateCheck othersateCheck;
    private Transform newParent;
    private GameObject storeOtherItem;
    private GameObject storeThisItem;
    private Items storeItem;
    private int oldSlot;
    [SerializeField]
    private int slot;
    private Inventory inventory;



    void Start()
    {
        sateCheck = gameObject.GetComponent<SateCheck>();
        inventory = GetComponentInParent<Inventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<DragnDrop>().Changing = true;
        newParent = eventData.pointerDrag.GetComponent<DragnDrop>().Oldparent;
        oldSlot = newParent.GetComponent<Drop>().Slot;
        othersateCheck = newParent.GetComponent<SateCheck>();
        storeItem = sateCheck.Slot.Item;
        storeOtherItem = eventData.pointerDrag;
        storeThisItem = sateCheck.ActiveItem;

        if(eventData.pointerDrag != null)
        {
            GameObject dragged = eventData.pointerDrag;
            if(sateCheck.Slot.Filled == false)
            {
                eventData.pointerDrag.transform.position = transform.position;
                eventData.pointerDrag.transform.SetParent(transform);
                sateCheck.Slot.Filled = true;
                sateCheck.ActiveItem = eventData.pointerDrag;
                othersateCheck.ActiveItem = null;
                othersateCheck.Slot.Filled = false;
                inventory.ItemChange(oldSlot, Slot, othersateCheck.Slot.Item);
                sateCheck.recieve(othersateCheck.Slot.Item);
                othersateCheck.give();
            }
            else if(sateCheck.Slot.Filled == true)
            {
                storeOtherItem.transform.position = transform.position;
                storeOtherItem.transform.SetParent(transform);
                sateCheck.ActiveItem = storeOtherItem;
                storeThisItem.transform.position = newParent.position;
                storeThisItem.transform.SetParent(newParent);
                othersateCheck.ActiveItem = storeThisItem;
                inventory.ItemSwitch(oldSlot, Slot, othersateCheck.Slot.Item, sateCheck.Slot.Item);
                sateCheck.recieve(othersateCheck.Slot.Item);
                othersateCheck.recieve(storeItem);
            }
        }

    }

    //getters setters
    public int Slot
    {
        get { return slot; }
        set { slot = value; }
    }
}
