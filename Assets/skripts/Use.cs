using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use : MonoBehaviour
{
    [SerializeField]
    private Items item;

    public void use()
    {
        if (item.ID == 1)
        {
            Debug.Log("Pickup 1");
        }
        else if(item.ID == 0)
        {
            Debug.Log("Pickup 0");
        }
    }

    public void attack()
    {

    }

    public void altAttack()
    {

    }

    public Items Item
    {
        get { return item; }
        set { item = value; }
    }
}
