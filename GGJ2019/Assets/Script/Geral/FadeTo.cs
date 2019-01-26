using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTo : MonoBehaviour
{
    public float speedFade;
    private Color colorT;
    public bool isImage;
    private void Awake()
    {
        if(isImage)
        colorT = this.GetComponent<Image>().color;
        else
            colorT = this.GetComponent<Text>().color;
        colorT.a = 0;
        if(isImage)
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
        if (colorT.a < 1)
        {
            colorT.a += speedFade * Time.deltaTime;
            if(isImage)
            this.GetComponent<Image>().color = colorT;
            else
                this.GetComponent<Text>().color = colorT;

        }
    }
}
