using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragnDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private SateCheck sateCheck;

    [SerializeField]
    private CanvasGroup CG;

    private Transform oldparent;
    private bool changing = false;

    void Start()
    {
        sateCheck = GetComponentInParent<SateCheck>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        CG.blocksRaycasts = false;
        oldparent = transform.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CG.blocksRaycasts = true;
        if(changing == false)
        {
            transform.position = oldparent.position;
        }
        else if (changing == true)
        {
            changing = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
    
    //getters setters
    public Transform Oldparent
    {
        get { return oldparent; }
        set { oldparent = value; }
    }

    public bool Changing
    {
        get { return changing; }
        set { changing = value; }
    }
}
