using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerScript : MonoBehaviour
{
    public List<GameObject> items;
    public List<GameObject> itemsBack;
    public List<GameObject> itemsFase8;
    public GameObject trigger;
    public float cd;
    public int stage;
    private bool callItemBack;
    private AudioManager audioManager;
    public int indexSec;
    public bool isStage8;
    private TextManager textManager;


    void Start()
    {
        textManager = GameObject.Find("TextManagerText").GetComponent<TextManager>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Global.powerIsActive)
        {
            this.GetComponent<Button>().interactable = false;
        }
        else
        {
            this.GetComponent<Button>().interactable = true;
        }
    }

    public void FindObjects()
    {
        if (stage == 8)
        {
            textManager.TextStartCoroutine(indexSec, 0, 9);
            StartCoroutine(Fase8());
        }
        else
        {
            Global.powerIsActive = true;
            if (items.Count == 0)
                StartCoroutine(endPower());

            else
                StartCoroutine(DisableObjects());
        }
    }

    public IEnumerator DisableObjects()
    {
        for (int i = 0; i < items.Count; i++)
        {
            yield return new WaitForSeconds(1);
            items[i].SetActive(false);
            if(i == items.Count-1)
            {
                StartCoroutine("CallBack");
            }
        }
        callItemBack = true;
        Global.powerIsActive = false;
    }

    public IEnumerator CallBack()

    {
        yield return new WaitForSeconds(items.Count + 2);
        for (int i = 0; i < items.Count; i++)
        {
            yield return new WaitForSeconds(1);
            items[i].SetActive(true);
        }

    }

    public IEnumerator endPower()
    {
        yield return new WaitForSeconds(5);
        Global.powerIsActive = false;
    }

    IEnumerator Fase8()
    {
        Debug.Log("Couroutine Fase 8");
        Debug.Log(items.Count);
        for (int i = 0; i < itemsFase8.Count; i++)
        {
            yield return new WaitForSeconds(1);
            itemsFase8[i].SetActive(true);
        }
        yield return new WaitForSeconds(1);
        trigger.SetActive(true);
    }

}
