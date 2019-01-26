using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ModelTextScript : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Color color;
    public float speedFade;
    public float timeToEnd;
    private bool canEnd;
    public bool changeName;

    private void Awake()
    {
        text = this.GetComponent<TextMeshProUGUI>();
        if (changeName)
            this.text.text = "Level " + (SceneManager.GetActiveScene().buildIndex + 1);
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
