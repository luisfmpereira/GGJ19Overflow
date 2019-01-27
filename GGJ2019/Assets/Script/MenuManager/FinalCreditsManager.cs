using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalCreditsManager : MonoBehaviour
{
   public GameObject credits;
   public GameObject thanks;

    void Update(){
        StartCoroutine("ShowCredits");
    }


   IEnumerator ShowCredits(){

       yield return new WaitForSeconds(5);
       credits.SetActive(true);
       yield return new WaitForSeconds(2);
       thanks.SetActive(true);
       yield return new WaitForSeconds(5);
       SceneManager.LoadScene("Main");

   }
}
