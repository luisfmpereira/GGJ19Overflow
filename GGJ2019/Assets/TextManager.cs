using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    private Color colorText;

    public string[] texts;

    public static TextManager instance;

    private bool started = true;

    private bool end;


    void Awake()
    {
        colorText = this.GetComponent<TextMeshProUGUI>().color;
       
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(this.transform.parent.gameObject);
            }
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.transform.parent.gameObject);
        }
    }
    private void Update()
    {
        this.GetComponent<TextMeshProUGUI>().color = colorText;

        if (colorText.a < 1 && started)
        {
            colorText.a += 1 * Time.deltaTime;
        }
        else
        {

            started = false;
            colorText.a = 1;
        }
        if (colorText.a > 0 && end)
        {
            colorText.a -= 1.1f * Time.deltaTime;
        }
    }
    public IEnumerator ShowText(int index, float timeToStart, float timeToDisappear)
    {

        yield return new WaitForSeconds(timeToStart);
        this.GetComponent<TextMeshProUGUI>().text = texts[index];
        colorText.a = 0;
        this.GetComponent<TextMeshProUGUI>().enabled = true;
        
        yield return new WaitForSeconds(timeToDisappear - 1);
        end = true;
        colorText.a = 0;
        this.GetComponent<TextMeshProUGUI>().enabled = false;
    }
    public void TextStartCoroutine(int index, float timeToStart, float timeToDisappear)
    {
        StartCoroutine(ShowText(index, timeToStart, timeToDisappear));
    }


}
