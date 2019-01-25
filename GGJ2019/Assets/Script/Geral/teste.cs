using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teste : MonoBehaviour
{
    public Color defaultColor;
    public Color selectedColor;

    void OnTouchDown()
    {
        this.GetComponent<SpriteRenderer>().color = selectedColor;
    }
    void OnTouchUp()
    {
        this.GetComponent<SpriteRenderer>().color = defaultColor;
    }
    void OnTouchStay()
    {
        this.GetComponent<SpriteRenderer>().color = selectedColor;
    }
    void OnTouchExit()
    {
        this.GetComponent<SpriteRenderer>().color = defaultColor;
    }

}