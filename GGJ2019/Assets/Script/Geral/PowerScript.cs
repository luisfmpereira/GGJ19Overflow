using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    public List<GameObject> items;
    public List<GameObject> itemsBack;
    public float cd;
    private bool callItemBack;
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(callItemBack)
        {
            CallBack();
        }
    }

    public void FindObjects()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Disappear"))
        {
            items.Add(go);
        }
        StartCoroutine(DisableObjects());
    }

    public IEnumerator DisableObjects()
    {
        for (int i = 0; i < items.Count; i++)
        {
            yield return new WaitForSeconds(1);
            items[i].SetActive(false);
        }
        callItemBack = true;

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

}
