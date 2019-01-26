using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ModelTextScript : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Color color;
    public float speedFade;

    private void Awake()
    {
        text = this.GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        color = text.color;
        color.a = 0;
        text.color = color;
    }
    private void Update()
    {
        if (color.a < 1)
        {
            color.a += speedFade * Time.deltaTime;
            text.color = color;
        }
    }

}
