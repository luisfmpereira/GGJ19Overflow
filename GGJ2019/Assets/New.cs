using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class New : MonoBehaviour
{
    private Image mg;
    private Color color;
    public float speedFade;
    public float timeToEnd;
    private bool canEnd;
    public bool changeName;

    private void Awake()
    {
        mg = this.GetComponent<Image>();
    }
    private void OnEnable()
    {
        color = mg.color;
        color.a = 0;
        mg.color = color;
        StartCoroutine(Wait());
    }
    private void Update()
    {
        if (color.a < 1 && !canEnd)
        {
            color.a += speedFade * Time.deltaTime;
            mg.color = color;
        }
        if(canEnd && color.a > 0)
        {
            color.a -= speedFade * Time.deltaTime;
            mg.color = color;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeToEnd);
        canEnd = true;

    }
}
