using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Items 
{
    public int ID;
    public string name;
    public int count;

    public Items(int IDHere, string nameHere, int countHere)
    {
        ID = IDHere;
        name = nameHere;
        count = countHere;
    }

    public Items(int IDHere, string nameHere)
    {
        ID = IDHere;
        name = nameHere;
    }
}
