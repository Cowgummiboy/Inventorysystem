using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SateCheck : MonoBehaviour
{
    private Slots slot = new Slots();

    [SerializeField]
    private GameObject[] Items;
    private GameObject selectItem;
    private GameObject activeItem;

    public void fill(Items item)
    {
        slot.Item = item;

        foreach(GameObject forItems in Items)
        {
            if(forItems.GetComponent<Use>().Item.ID == item.ID)
            {
                selectItem = forItems;
            }
        }

        activeItem = Instantiate<GameObject>(selectItem, transform.position, Quaternion.identity, transform);

        slot.Filled = true;                                                                                                          
    }

    public void add(int count)
    {
        slot.Item = new Items(slot.Item.ID, slot.Item.name, slot.Item.count + count);
    }

    public void give()
    {
        slot.Item = null;
    }

    public void recieve(Items item)
    {
        slot.Item = item;
    }


    //getter setters
    public Slots Slot
    {
        get { return slot;}
        set { slot = value; }
    }

    public GameObject ActiveItem
    {
        get { return activeItem; }
        set { activeItem = value; }
    }
}
