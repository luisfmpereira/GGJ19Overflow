using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerScript : MonoBehaviour
{
    public List<GameObject> items;
    public List<GameObject> itemsBack;
    public float cd;
    private bool callItemBack;
    private AudioManager audioManager;
    

    void Start()
    {
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
        audioManager.PlaySound("Focus");
        Global.powerIsActive = true;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Disappear"))
        {
            items.Add(go);
        }
        if (items.Count == 0)
            StartCoroutine(endPower());

        else
        StartCoroutine(DisableObjects());
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

}
