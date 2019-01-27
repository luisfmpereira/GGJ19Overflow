﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerChapter2 : MonoBehaviour
{

    public List<GameObject> path;
    public int triggerCount;
    public Material useMAt;
    public GameObject leftDoor;
    public GameObject rightDoor;
    private Vector3 leftClose;
    private Vector3 rightClose;
    private Vector3 leftOpen;
    private Vector3 rightOpen;
    public float timeToClose;
    public float timeToOpen;
    Hashtable openLeftDoor = new Hashtable();
    Hashtable openRightDoor = new Hashtable();
    Hashtable closeLeftDoor = new Hashtable();
    Hashtable closeRightDoor = new Hashtable();


    private void Awake()
    {
        leftClose = leftDoor.transform.position;
        rightClose = rightDoor.transform.position;
        leftOpen = leftDoor.transform.position;
        rightOpen = rightDoor.transform.position;
        leftOpen.z += 1.8f;
        rightOpen.z -= 1.8f;



        MoveTween(leftOpen, timeToOpen, openLeftDoor);
        MoveTween(rightOpen, timeToOpen, openRightDoor);
        MoveTween(leftClose, timeToClose, closeLeftDoor);
        MoveTween(rightClose, timeToClose, closeRightDoor);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TriggerPath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TriggerPath()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            if(triggerCount == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    path[i].GetComponent<Renderer>().material = useMAt;
                    yield return new WaitForSeconds(0.5f);
                }
            }
            else if (triggerCount == 2)
            {
                for (int i = 4; i < 8; i++)
                {
                    path[i].GetComponent<Renderer>().material = useMAt;
                    yield return new WaitForSeconds(0.5f);
                }
            }
            else if (triggerCount == 3)
            {
                for (int i = 8; i < 12; i++)
                {
                    path[i].GetComponent<Renderer>().material = useMAt;
                    yield return new WaitForSeconds(0.2f);
                }
                iTween.MoveTo(leftDoor, openLeftDoor);
                iTween.MoveTo(rightDoor, openRightDoor);
            }
        }
    }
    private void MoveTween(Vector3 pos, float time, Hashtable hash)
    {
        hash.Clear();
        hash.Add("time", time);
        hash.Add("position", pos);
    }
}