using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField]
    private GameObject Inventory;

    private Inventory Inventorys;
    [SerializeField]
    private Items item;


    private void Start()
    {
        Inventorys = Inventory.GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collected();
    }

    private void collected()
    {
        Inventorys.AddItem(item);
        Destroy(gameObject);
    }

    //getters setters
    public Items Item
    {
        get { return item; }
        set { item = value; }
    }
}
