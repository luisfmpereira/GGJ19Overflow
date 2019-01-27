using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int nextScene;

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
