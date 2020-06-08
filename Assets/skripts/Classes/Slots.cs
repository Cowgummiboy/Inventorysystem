using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Slots
{
    private bool filled = false;

    private Items item = null;

    //getters setters
    public bool Filled
    {
        get { return filled; }
        set { filled = value; }
    }

    public Items Item
    {
        get { return item; }
        set { item = value; }
    }

}
