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
    public float timeToEnd;
    private bool canEnd;

    private void Awake()
    {
        text = this.GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        color = text.color;
        color.a = 0;
        text.color = color;
        StartCoroutine(Wait());
    }
    private void Update()
    {
        if (color.a < 1 && !canEnd)
        {
            color.a += speedFade * Time.deltaTime;
            text.color = color;
        }
        if(canEnd && color.a > 0)
        {
            color.a -= speedFade * Time.deltaTime;
            text.color = color;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeToEnd);
        canEnd = true;

    }
}
