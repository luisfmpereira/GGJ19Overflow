using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TapToStart : MonoBehaviour
{
    public bool isTapped;
    public GameObject fade;
    public float speedFade;
    private Color colorT;
    private TextManager textManager;
    public int indexStart;
    // Start is called before the first frame update
    void Start()
    {
        textManager = GameObject.Find("TextManagerText").GetComponent<TextManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IsTappedMethod()
    {
        fade.GetComponent<FadeInAndOut>().change = 0;
    }
    public void StartText()
    {
        textManager.TextStartCoroutine(indexStart, 0, 5);
    }
}
