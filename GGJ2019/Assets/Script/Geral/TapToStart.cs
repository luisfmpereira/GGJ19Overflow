using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TapToStart : MonoBehaviour
{
    public bool isTapped;
    public GameObject fade;
    public float speedFade;
    private Color colorT;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IsTappedMethod()
    {
        fade.GetComponent<FadeInAndOut>().change = 0;
    }
}
