using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SceneLoading(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
