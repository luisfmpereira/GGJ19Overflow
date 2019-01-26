using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    public List<GameObject> items;
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
        yield return new WaitForSeconds(Random.Range(0.5f, 2));
        int random = Random.Range(0, items.Count);
        items[random].SetActive(false);
        items.RemoveAt(random);
        yield return new WaitForSeconds(Random.Range(0.5f, 2));
        random = Random.Range(0, items.Count);
        items[random].SetActive(false);
        items.RemoveAt(random);
        yield return new WaitForSeconds(Random.Range(0.5f, 2));
        random = Random.Range(0, items.Count);
        items[random].SetActive(false);
        items.RemoveAt(random);
    }
}
