using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeScene : MonoBehaviour
{
    public int nextScene;
    TextMeshProUGUI textManager;
public bool home;

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
       if(home)
       textManager.enabled = false;
    }
    private void Awake()
    {
        textManager = GameObject.Find("TextManagerText").GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {

    }
}
