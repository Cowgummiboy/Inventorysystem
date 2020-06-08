using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] private GameObject[] HotbarSlot;
    private Use use;

    private int position = 0;

    private void Start()
    {
        if (transform.parent.GetComponentInChildren<Use>() != null)
        {
            use = transform.parent.GetComponentInChildren<Use>();
        }
    }

    private void Update()
    {
        if(Input.mouseScrollDelta.y < 0)
        {
            if (position < 8)
                position += 1;
            transform.SetParent(HotbarSlot[position].transform);
            transform.position = HotbarSlot[position].transform.position;
            if (transform.parent.GetComponentInChildren<Use>() != null)
            {
                use = transform.parent.GetComponentInChildren<Use>();
            }
            else
            {
                use = null;
            }
        }
        else if(Input.mouseScrollDelta.y > 0)
        {
            if (position > 0)
                position -= 1;
            transform.SetParent(HotbarSlot[position].transform);
            transform.position = HotbarSlot[position].transform.position;
            if (transform.parent.GetComponentInChildren<Use>() != null)
            {
                use = transform.parent.GetComponentInChildren<Use>();
            }
            else
            {
                use = null;
            }
        }

        if (Input.GetKeyDown("e"))
        {
            if(use != null)
            {
                use.use();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Hello");
        }
    }

    public void reassignUse()
    {
        if (transform.parent.GetComponentInChildren<Use>() != null)
        {
            use = transform.parent.GetComponentInChildren<Use>();
        }
        else
        {
            use = null;
        }
    }
}
