using System.Collections;
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
    private bool phase1;
    private bool phase2;
    private bool phase3;
    private bool phase4;
    public GameObject hide;
    public int phase;


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
            if (phase == 1)
            {
                if (triggerCount == 1 && !phase1)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        path[i].GetComponent<Renderer>().material = useMAt;
                        yield return new WaitForSeconds(0.3f);
                    }
                    hide.SetActive(true);
                    iTween.MoveTo(leftDoor, openLeftDoor);
                    iTween.MoveTo(rightDoor, openRightDoor);
                }
            }
            else if(phase == 2 || phase == 3 || phase == 6)
            {
                if (triggerCount == 1 && !phase1)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        path[i].GetComponent<Renderer>().material = useMAt;
                        yield return new WaitForSeconds(0.3f);
                    }
                    phase1 = true;
                }
                else if (triggerCount == 2 && !phase2)
                {
                    for (int i = 4; i < 8; i++)
                    {
                        path[i].GetComponent<Renderer>().material = useMAt;
                        yield return new WaitForSeconds(0.3f);
                    }
                    phase2 = true;
                }
                else if (triggerCount == 3)
                {
                    for (int i = 8; i < 12; i++)
                    {
                        yield return new WaitForSeconds(0.3f);
                        path[i].GetComponent<Renderer>().material = useMAt;

                    }
                    hide.SetActive(true);
                    iTween.MoveTo(leftDoor, openLeftDoor);
                    iTween.MoveTo(rightDoor, openRightDoor);
                }
            }
            else if(phase == 4)
            {
                if (triggerCount == 1 && !phase1)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        path[i].GetComponent<Renderer>().material = useMAt;
                        yield return new WaitForSeconds(0.3f);
                    }
                    phase1 = true;
                }
                else if (triggerCount == 2 && !phase2)
                {
                    for (int i = 6; i < 12; i++)
                    {
                        path[i].GetComponent<Renderer>().material = useMAt;
                        yield return new WaitForSeconds(0.3f);
                    }
                    phase2 = true;
                    hide.SetActive(true);
                    iTween.MoveTo(leftDoor, openLeftDoor);
                    iTween.MoveTo(rightDoor, openRightDoor);
                }

            }
            else if (phase == 4 || phase == 7)
            {
                if (triggerCount == 1 && !phase1)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        path[i].GetComponent<Renderer>().material = useMAt;
                        yield return new WaitForSeconds(0.3f);
                    }
                    phase1 = true;
                }
                else if (triggerCount == 2 && !phase2)
                {
                    for (int i = 4; i < 8; i++)
                    {
                        path[i].GetComponent<Renderer>().material = useMAt;
                        yield return new WaitForSeconds(0.3f);
                    }
                    phase2 = true;
                }
                else if (triggerCount == 3)
                {
                    for (int i = 8; i < 12; i++)
                    {
                        yield return new WaitForSeconds(0.3f);
                        path[i].GetComponent<Renderer>().material = useMAt;

                    }
       
                }
                else if (triggerCount == 4)
                {
                    for (int i = 12; i < 16; i++)
                    {
                        yield return new WaitForSeconds(0.3f);
                        path[i].GetComponent<Renderer>().material = useMAt;

                    }
                    hide.SetActive(true);
                    iTween.MoveTo(leftDoor, openLeftDoor);
                    iTween.MoveTo(rightDoor, openRightDoor);
                }
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
