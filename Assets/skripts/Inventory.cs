using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Items[] items = new Items[15];

    private SateCheck[] states = new SateCheck[15];

    private Scroll scroll;

    void Start()
    {
        scroll = GetComponentInChildren<Scroll>();
        states = GetComponentsInChildren<SateCheck>();
        Debug.Log(states[0]);
        //for (int i = 0; i < 6; i++)
        //{
        //    state[i] = slot[i].GetComponent<SateCheck>();
        //}
    }

    public void AddItem(Items item)
    {
        for (int i = 0; i < 6; i++)
        {
            if(states[i].Slot.Filled == false)
            {
                items[i] = item;
                states[i].fill(item);
                scroll.reassignUse();
                break;
            }

            if(states[i].Slot.Filled == true && items[i].ID == item.ID)
            {
                items[i].count += item.count;
                states[i].add(item.count);
                scroll.reassignUse();
                break;
            }
        }
    }
    public void ItemChange(int oldSlot, int newSlot, Items item)
    {
        items[oldSlot] = null;
        items[newSlot] = item;
        scroll.reassignUse();
    }

    public void ItemSwitch(int oldSlot, int newSlot, Items oldItem, Items newItems)
    {
        items[oldSlot] = newItems;
        items[newSlot] = oldItem;
        scroll.reassignUse();
    }
}
