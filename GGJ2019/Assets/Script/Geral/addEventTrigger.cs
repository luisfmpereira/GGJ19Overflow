﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addEventTrigger : MonoBehaviour
{
    //IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler


    #region Variables
    public int actualObj;
    public LayerMask touchInputMask;
    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;
    private RaycastHit hit;
    #endregion
    //[SPACE]
    //[HEADER()]


    #region Unity Methods
    private void Awake()
    {

    }
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, touchInputMask))
            {
                GameObject recipient = hit.transform.gameObject;
                touchList.Add(recipient);
                if (Input.GetMouseButtonDown(0))
                {
                    recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                }

                if (Input.GetMouseButton(0))
                {
                    recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                }

            }
            foreach (GameObject g in touchesOld)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }





#endif

        if (Input.touchCount > 0)
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();
            foreach (Touch t in Input.touches)
            {

                Ray ray = Camera.main.ScreenPointToRay(t.position);

                if (Physics.Raycast(ray, out hit, touchInputMask))
                {
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);
                    if (t.phase == TouchPhase.Began)
                    {
                        recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                        Debug.Log("OnTouchDown");
                    }
                    if (t.phase == TouchPhase.Ended)
                    {
                        recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                    }

                    if (t.phase == TouchPhase.Stationary || t.phase == TouchPhase.Moved)
                    {
                        recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                    }

                    if (t.phase == TouchPhase.Canceled)
                    {
                        recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
            foreach (GameObject g in touchesOld)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("Saindo");
                }
            }
        }

    }

    /*
	public void OnPointerEnter(PointerEventData eventData)
	{
        Touch myTouch = Input.GetTouch(0);

        Touch[] myTouches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {
            Debug.Log("OnPointerEnter");
            myFill.touchesRight--;
        }

	}
	public void OnPointerExit(PointerEventData eventData)
	{
        Touch myTouch = Input.GetTouch(0);

        Touch[] myTouches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {
            Debug.Log("OnPointerExit");
            myFill.touchesRight++;
        }
  
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		//Debug.Log("OnPointerClick");
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		//Debug.Log("OnPointerDown");
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		//Debug.Log("OnPointerUp");
	}
	public void OnSelect(BaseEventData eventData)
	{
		//Debug.Log("OnSelect");
	}
    */
}
#endregion
