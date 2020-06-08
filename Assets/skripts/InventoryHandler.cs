using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    private bool open = false;
    [SerializeField] private GameObject[] closable;


    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            for (int i = 0; i < closable.Length; i++)
            {
                closable[i].SetActive(!closable[i].activeSelf);
            }
            open = !open;
        }

        if (Input.GetKeyDown("escape") && open == true)
        {
            for (int i = 0; i < closable.Length; i++)
            {
                closable[i].SetActive(false);
            }
            open = false;
        }
    }
}
