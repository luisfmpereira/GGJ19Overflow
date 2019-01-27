using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject back;
    public GameObject mainButtons;
    public GameObject credits;
    public GameObject selection;

    public void CreditsClick(){
        back.SetActive(true);
        mainButtons.SetActive(false);
        credits.SetActive(true);
    }

    public void LevelSelection(){
        back.SetActive(true);
        mainButtons.SetActive(false);
        selection.SetActive(true);
    }

    public void BackClick(){
        back.SetActive(false);
        mainButtons.SetActive(true); 
        credits.SetActive(false);
        selection.SetActive(false);
    }
}
