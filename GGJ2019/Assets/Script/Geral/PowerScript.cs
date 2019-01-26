using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    public List<GameObject> items;
    public List<GameObject> itemsBack;
    public float cd;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
            int random = Random.Range(0, items.Count);
            items[random].SetActive(false);
            itemsBack.Add(items[random]);
            items.RemoveAt(random);
        }
        yield return new WaitForSeconds(cd);
        for (int i = 0; i < itemsBack.Count; i++)
        {
            itemsBack[i].SetActive(true);
        }
    }

}
