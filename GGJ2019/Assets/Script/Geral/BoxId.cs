using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxId : MonoBehaviour
{
    public int Id;
    [Header("Change Color")]
    public bool willChangeColor;
    public Material realColor;
    public Material whiteColor;


    private void Start()
    {
        if(willChangeColor)
        StartCoroutine(IsUsingThePower());
    
    }

    private void Update()
    {

    }

    IEnumerator IsUsingThePower()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if(Global.powerIsActive)
            {
                this.gameObject.GetComponent<Renderer>().material = realColor;
            }
            else
            {
                this.gameObject.GetComponent<Renderer>().material = whiteColor;
            }
        } 
    }

}
