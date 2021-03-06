﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInAndOut : MonoBehaviour
{
    public float speedFade;
    private Color colorT;
    public float change;
    private void Awake()
    {
        colorT = this.GetComponent<Image>().color;
        colorT.a = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (colorT.a  > change)
         {       
            colorT.a -= speedFade * Time.deltaTime;
            this.GetComponent<Image>().color = colorT;
        }
    }

    public void FadeOut()
    {
        if (colorT.a < 1)
        {
            colorT = this.GetComponent<Image>().color;
            colorT.a += speedFade * Time.deltaTime;
            this.GetComponent<Image>().color = colorT;
        }
    }

}
