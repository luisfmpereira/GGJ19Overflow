using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TapToStart : MonoBehaviour, IPointerDownHandler
{
    public bool isTapped;
    public GameObject fade;
    public float speedFade;
    private Color colorT;
    private TextManager textManager;
    public int indexStart;
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;
    public GameObject f;


    // Start is called before the first frame update
    void Start()
    {
        textManager = GameObject.Find("TextManagerText").GetComponent<TextManager>();
    }

    // Update is called once per frame

    public void IsTappedMethod()
    {
        fade.GetComponent<FadeInAndOut>().change = 0;
    }
    public void StartText()
    {
        textManager.TextStartCoroutine(indexStart, 0, 9);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        IsTappedMethod();
        StartText();
        a.SetActive(true);
        b.SetActive(false);
        c.SetActive(false);
        d.SetActive(false);
        e.SetActive(false);
        f.SetActive(false);
    }
}
