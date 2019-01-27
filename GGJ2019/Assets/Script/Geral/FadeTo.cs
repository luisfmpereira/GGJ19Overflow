using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTo : MonoBehaviour
{
    public float speedFade;
    private Color colorT;
    public bool isImage;

    public bool fadeOut;
    private void Awake()
    {


        if (isImage)
            colorT = this.GetComponent<Image>().color;
        else
            colorT = this.GetComponent<Text>().color;
        if (!fadeOut)
            colorT.a = 0;
        else
            colorT.a = 1;
        if (isImage)
            this.GetComponent<Image>().color = colorT;
        else
            this.GetComponent<Text>().color = colorT;
    }

    private void OnEnable()
    {


    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!fadeOut)
        {
            if (colorT.a < 1)
            {
                colorT.a += speedFade * Time.deltaTime;
                if (isImage)
                    this.GetComponent<Image>().color = colorT;
                else
                    this.GetComponent<Text>().color = colorT;

            }
        }

        else if (fadeOut)
        {
            if (colorT.a >= 0)
            {
                colorT.a -= speedFade * Time.deltaTime;
                if (isImage)
                    this.GetComponent<Image>().color = colorT;
                else
                    this.GetComponent<Text>().color = colorT;

            }
        }
    }
}
