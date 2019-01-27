using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject back;
    public GameObject mainButtons;
    public GameObject credits;
    public GameObject selection;

    public GameObject startText;
    public GameObject player;
    public GameObject title;

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

    public void NewGame(){
        title.SetActive(false);
        player.SetActive(true);
        startText.SetActive(true);
        mainButtons.SetActive(false);
        StartCoroutine("WaitForNew");
    }

    IEnumerator WaitForNew(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Chapter1");
    }
}
