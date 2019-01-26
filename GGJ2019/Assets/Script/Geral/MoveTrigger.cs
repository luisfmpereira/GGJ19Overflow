using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour
{
    private int count;
    public bool willOpenDoor;
    [Header("OpenDoor")]
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
    // Start is called before the first frame update
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
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (count == 0)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, 0.01f, this.transform.position.z), 3);
            iTween.MoveTo(leftDoor, openLeftDoor);
            iTween.MoveTo(rightDoor, openRightDoor);
        }
        count++;
       
      
    }
    private void OnTriggerExit(Collider other)
    {
        if(count == 1)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, 0.05f, this.transform.position.z), 3);
            iTween.MoveTo(leftDoor, closeLeftDoor);
            iTween.MoveTo(rightDoor, closeRightDoor);
        }
        count--;
      
    }
 
    private void MoveTween(Vector3 pos, float time, Hashtable hash){
        hash.Clear();
        hash.Add("time", time);
        hash.Add("position", pos);
    }
}
