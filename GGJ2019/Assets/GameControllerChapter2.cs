using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerChapter2 : MonoBehaviour
{
    private AudioSource sound8;
    private AudioSource sound9;
    public float volume8;
    public float volume9;
    public bool happy;
    public bool sad;
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
    private AudioManager audioManager;
    public GameObject exitCollider;

    [Header("Frase")]
    public int indexFrase;
    private TextManager textManager;


    private void Awake()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        textManager = GameObject.Find("TextManagerText").GetComponent<TextManager>();
        leftClose = leftDoor.transform.position;
        rightClose = rightDoor.transform.position;
        leftOpen = leftDoor.transform.position;
        rightOpen = rightDoor.transform.position;
        leftOpen.z += 1.8f;
        rightOpen.z -= 1.8f;
        volume8 = 0.6f;
        volume9 = 0;


        MoveTween(leftOpen, timeToOpen, openLeftDoor);
        MoveTween(rightOpen, timeToOpen, openRightDoor);
        MoveTween(leftClose, timeToClose, closeLeftDoor);
        MoveTween(rightClose, timeToClose, closeRightDoor);
    }
    // Start is called before the first frame update
    void Start()
    {
        sound8 = GameObject.Find("Sound_8_GGJ8").GetComponent<AudioSource>();
        sound9 = GameObject.Find("Sound_9_10").GetComponent<AudioSource>();
        StartCoroutine(TriggerPath());
        if (phase == 1)
        {
            audioManager.PlaySound("GGJ8");
            audioManager.PlaySound("10");
        }
    }


    IEnumerator TriggerPath()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (phase == 1 || phase == 8)
            {
                if (triggerCount == 1 && !phase1)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        path[i].GetComponent<Renderer>().material = useMAt;
                        yield return new WaitForSeconds(0.3f);
                    }
                    phase1 = true;
                    hide.SetActive(true);
                    exitCollider.SetActive(false);
                    iTween.MoveTo(leftDoor, openLeftDoor);
                    iTween.MoveTo(rightDoor, openRightDoor);
                    textManager.TextStartCoroutine(indexFrase, 0, 9);
                    ChangeToHappy();

                }
            }
            else if (phase == 2 || phase == 3 || phase == 6)
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
                else if (triggerCount == 3 && !phase3)
                {
                    for (int i = 8; i < 12; i++)
                    {
                        yield return new WaitForSeconds(0.3f);
                        path[i].GetComponent<Renderer>().material = useMAt;

                    }
                    phase3 = true;
                    hide.SetActive(true);
                    exitCollider.SetActive(false);
                    iTween.MoveTo(leftDoor, openLeftDoor);
                    iTween.MoveTo(rightDoor, openRightDoor);
                    textManager.TextStartCoroutine(indexFrase, 0, 9);
                    ChangeToHappy();
                }
            }
            else if (phase == 4)
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
                    exitCollider.SetActive(false);
                    iTween.MoveTo(leftDoor, openLeftDoor);
                    iTween.MoveTo(rightDoor, openRightDoor);
                    textManager.TextStartCoroutine(indexFrase, 0, 9);
                    ChangeToHappy();
                }

            }
            else if (phase == 7 || phase == 5)
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
                else if (triggerCount == 3 && !phase3)
                {
                    for (int i = 8; i < 12; i++)
                    {
                        yield return new WaitForSeconds(0.3f);
                        path[i].GetComponent<Renderer>().material = useMAt;

                    }
                    phase3 = true;
                }
                else if (triggerCount == 4)
                {
                    for (int i = 12; i < 16; i++)
                    {
                        yield return new WaitForSeconds(0.3f);
                        path[i].GetComponent<Renderer>().material = useMAt;

                    }
                    hide.SetActive(true);
                    exitCollider.SetActive(false);
                    iTween.MoveTo(leftDoor, openLeftDoor);
                    iTween.MoveTo(rightDoor, openRightDoor);
                    textManager.TextStartCoroutine(indexFrase, 0, 9);
                    ChangeToHappy();
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

    private void Update()
    {
        if(happy)
        {
            if(audioManager.sounds[8].volume > 0)
            {
                volume8 -= Time.deltaTime * 0.3f;
            }
            if(audioManager.sounds[9].volume < 0.6)
            {
                volume9 += Time.deltaTime * 0.1f;
            }
            if(audioManager.sounds[8].volume <= 0 && audioManager.sounds[9].volume >= 0.6)
            {
                happy = false;
            }
        }
        if (sad)
        {
            if (audioManager.sounds[9].volume > 0)
            {
                volume8 -= Time.deltaTime * 0.3f;
            }
            if (audioManager.sounds[8].volume < 0.6)
            {
                volume9 += Time.deltaTime * 0.1f;
            }
            if (audioManager.sounds[9].volume <= 0 && audioManager.sounds[8].volume >= 0.6)
            {
                sad = false;
            }
        }
        sound8.volume = volume8;
        sound9.volume = volume9;
    }

    void ChangeToHappy()
    {
        happy = true;
    }

    void ChangeToSad()
    {
        sad = true;
    }
}
