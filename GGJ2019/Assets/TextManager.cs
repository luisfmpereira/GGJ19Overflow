using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    private Color colorText;

    public string[] texts;

    public static TextManager instance;

    private bool started ;

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
        if (colorText.a > 0 && end)
        {
            colorText.a -= 1 * Time.deltaTime;
        }
    }
     IEnumerator ShowText(int index, float timeToStart, float timeToDisappear)
    {   
        yield return new WaitForSeconds(timeToStart);
        this.GetComponent<TextMeshProUGUI>().text = texts[index];
        colorText.a = 0;
        started = true;
        this.GetComponent<TextMeshProUGUI>().enabled = true;  
        yield return new WaitForSeconds(timeToDisappear - 1);
        started = false;
        end = true;
        yield return new WaitForSeconds(1);
        this.GetComponent<TextMeshProUGUI>().enabled = false;
        end = false;
    }
    public void TextStartCoroutine(int index, float timeToStart, float timeToDisappear)
    {
        StartCoroutine(ShowText(index, timeToStart, timeToDisappear));
    }


}
