using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTo : MonoBehaviour
{

    Hashtable fade = new Hashtable();

    private void OnEnable()
    {
        iTween.FadeUpdate(this.gameObject, 0, 4);
    }

    // Start is called before the first frame update
    void Start()
    {
        iTween.FadeUpdate(this.gameObject, 0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
